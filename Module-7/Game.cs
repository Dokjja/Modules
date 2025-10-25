using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Keys = OpenTK.Windowing.GraphicsLibraryFramework.Keys;

namespace Module_7
{
    public class Game : GameWindow
    {
        Shader shader;
        int vbo;
        int vao;
        int vertexCount;

        Matrix4 modelMatrix = Matrix4.Identity;
        Matrix4 projectionMatrix = Matrix4.Identity;

        ObjModel model;

        // simple orbit camera
        float yaw = 0f;
        float pitch = 0f;
        float distance = 3.0f;
        Vector2 lastMousePos;
        bool rotating = false;

        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1f);
            GL.Enable(EnableCap.DepthTest);

            shader = new Shader("shader.vert", "shader.frag");
            shader.Use();

            // create VAO / VBO
            vao = GL.GenVertexArray();
            vbo = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            // layout: location 0 = vec3 position, 1 = vec2 texcoord, 2 = vec3 normal
            int stride = (3 + 2 + 3) * sizeof(float);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, stride, 0);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, stride, 3 * sizeof(float));
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, stride, (3 + 2) * sizeof(float));

            // default projection
            projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100f);

            // default model (small rotation so shading visible)
            modelMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-90));

            shader.SetVector3("lightColor", new Vector3(1f, 1f, 1f));
            shader.SetVector3("objectColor", new Vector3(1f, 1f, 1f));
            shader.SetInt("tex0", 0);

            // optionally you can pre-load a model here
            // Example: LoadModel("path/to/your.obj");
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            shader?.Dispose();
            if (vbo != 0) GL.DeleteBuffer(vbo);
            if (vao != 0) GL.DeleteVertexArray(vao);
            model?.Dispose();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45f),
                Size.X / (float)Size.Y,
                0.1f,
                100.0f
            );
        }
        private readonly Queue<Action> mainThreadActions = new();
    
        private void EnqueueOnMainThread(Action action)
        {
            lock (mainThreadActions)
                mainThreadActions.Enqueue(action);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // ✅ Run any actions queued from background threads
            lock (mainThreadActions)
            {
                while (mainThreadActions.Count > 0)
                    mainThreadActions.Dequeue().Invoke();
            }

            if (KeyboardState.IsKeyDown(Keys.Escape))
                Close();

            // open model loader with W (non-blocking dialog)
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                OpenFileDialogAndLoadModel();
            }
        }


        // thread-safe dialog open (same idea you had)
        volatile bool dialogOpen = false;
        void OpenFileDialogAndLoadModel()
        {
            if (dialogOpen) return;
            dialogOpen = true;

            Thread t = new Thread(() =>
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Wavefront OBJ|*.obj";
                string selected = null;

                if (ofd.ShowDialog() == DialogResult.OK)
                    selected = ofd.FileName;

                dialogOpen = false;

                if (selected != null)
                {
                    // ✅ run LoadModel() safely on the main (OpenGL) thread
                    EnqueueOnMainThread(() => LoadModel(selected));
                }
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        


        void LoadModel(string path)
        {
            model?.Dispose();
            var m = new ObjModel();
            m.LoadFromFile(path);

            var mtlPath = System.IO.Path.ChangeExtension(path, ".mtl");
            if (System.IO.File.Exists(mtlPath))
                m.LoadMtl(mtlPath);

            m.GenerateNormals();
            var vertexData = m.ToFloatArray();
            Console.WriteLine($"Model loaded: {m.Vertices.Count} vertices, {m.Faces.Count} faces, {vertexData.Length / 8} triangle vertices");

            if (vertexData.Length == 0)
            {
                Console.WriteLine("⚠️ No vertex data produced — OBJ parse failed?");
                return;
            }

            UploadVertexData(vertexData);
            model = m;
        }


        void UploadVertexData(float[] vertexData)
        {
            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticDraw);

            int stride = (3 + 2 + 3) * sizeof(float);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, stride, 0);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, stride, 3 * sizeof(float));
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, stride, (3 + 2) * sizeof(float));

            vertexCount = vertexData.Length / (3 + 2 + 3);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            shader.Use();

            // compute camera view matrix from yaw/pitch/distance
            Vector3 cameraPos = GetCameraPosition();
            Matrix4 view = Matrix4.LookAt(cameraPos, Vector3.Zero, Vector3.UnitY);

            shader.SetMatrix4("model", modelMatrix);
            shader.SetMatrix4("view", view);
            shader.SetMatrix4("projection", projectionMatrix);
            shader.SetVector3("viewPos", cameraPos);

            // bind texture if model has primary material (simple single-texture support)
            if (model != null && model.Materials.Count > 0)
            {
                // pick first material that has a texture
                var mat = model.Materials.Values.FirstOrDefault(m => m.TextureID != 0);
                if (mat != null)
                {
                    GL.ActiveTexture(TextureUnit.Texture0);
                    GL.BindTexture(TextureTarget.Texture2D, (int)mat.TextureID);
                }
            }
            if (vertexCount <= 0)
            {
                SwapBuffers();
                return;
            }

            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertexCount);


            SwapBuffers();
        }

        Vector3 GetCameraPosition()
        {
            // spherical coordinates
            float x = (float)(distance * Math.Cos(pitch) * Math.Sin(yaw));
            float y = (float)(distance * Math.Sin(pitch));
            float z = (float)(distance * Math.Cos(pitch) * Math.Cos(yaw));
            return new Vector3(x, y, z);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButton.Left)
            {
                rotating = true;
                var pos = MouseState.Position;
                lastMousePos = new Vector2((float)pos.X, (float)pos.Y);
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButton.Left)
            {
                rotating = false;
            }
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            if (rotating)
            {
                var pos = new Vector2((float)e.Position.X, (float)e.Position.Y);
                var delta = pos - lastMousePos;
                lastMousePos = pos;

                float sensitivity = 0.005f;
                yaw -= delta.X * sensitivity;
                pitch -= delta.Y * sensitivity;

                // clamp pitch so camera doesn't flip
                pitch = MathHelper.Clamp(pitch, -MathHelper.PiOver2 + 0.01f, MathHelper.PiOver2 - 0.01f);
            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            distance *= (float)Math.Pow(0.9, e.OffsetY); // zoom in/out
            distance = MathHelper.Clamp(distance, 0.1f, 50f);
        }
    }
}
