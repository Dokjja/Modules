using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing.Imaging;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using System.Globalization;

namespace Module_7
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var game = new Game(800, 600, "3D Model Viewer"))
            {
                game.Run(60.0);
            }
        }
    }
    public class Game : GameWindow
    {
        private ObjModel model = null;
        private float angleX = 0, angleY = 0;
        private int mouseX, mouseY;
        private float modelScale = 1;
        private bool isPressed = false;

        public Game(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.3f, 0.4f, 0.7f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Multisample);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.Normalize);
            
            SetupLighting();
            SetupMaterials();
        }

        private void SetupLighting()
        {
            float[] ambient = { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] diffuse = { 0.8f, 0.8f, 0.8f, 1.0f };
            float[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };

            GL.Light(LightName.Light0, LightParameter.Ambient, ambient);
            GL.Light(LightName.Light0, LightParameter.Diffuse, diffuse);
            GL.Light(LightName.Light0, LightParameter.Specular, specular);
        }

        private void SetupMaterials()
        {
            float[] matAmbient = { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] matDiffuse = { 0.6f, 0.6f, 0.6f, 1.0f };
            float[] matSpecular = { 0.9f, 0.9f, 0.9f, 1.0f };
            float[] matShininess = { 50.0f };

            GL.Material(MaterialFace.Front, MaterialParameter.Ambient, matAmbient);
            GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, matDiffuse);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, matSpecular);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, matShininess);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45f),
                Width / (float)Height,
                0.1f,
                100f);
            GL.LoadMatrix(ref perspective);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            
            if (Keyboard.GetState().IsKeyDown(Key.Escape))
                Exit();
                
            if (Keyboard.GetState().IsKeyDown(Key.W))
            {
                string path = ShowOpenFileDialog();
                if (!string.IsNullOrEmpty(path))
                {
                    model = new ObjModel().Load(path);
                }
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SetupModelView();
            
            if (model != null)
                DrawModel(model);

            SwapBuffers();
        }

        private void SetupModelView()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -5.0f);
            GL.Scale(modelScale, modelScale, modelScale);
            GL.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            GL.Rotate(angleY, 0.0f, 1.0f, 0.0f);
        }

        private void DrawModel(ObjModel model)
        {
            foreach (var face in model.Faces)
            {
                if (model.Materials.TryGetValue(face.MaterialName, out var mat) && mat.DiffuseTextureID != 0)
                {
                    GL.Enable(EnableCap.Texture2D);
                    GL.BindTexture(TextureTarget.Texture2D, mat.DiffuseTextureID);
                }
                else
                {
                    GL.Disable(EnableCap.Texture2D);
                }

                BeginPrimitive(face.VertexIndices.Length);
                
                foreach (var index in face.VertexIndices)
                {
                    var vertex = model.Vertices[index];
                    GL.Normal3(vertex.Normal);
                    GL.TexCoord2(vertex.TexCoord);
                    GL.Vertex3(vertex.Position);
                }

                GL.End();
            }
        }

        private void BeginPrimitive(int vertexCount)
        {
            switch (vertexCount)
            {
                case 3: GL.Begin(PrimitiveType.Triangles); break;
                case 4: GL.Begin(PrimitiveType.Quads); break;
                default: GL.Begin(PrimitiveType.Polygon); break;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (e.Button == MouseButton.Left)
            {
                mouseX = e.X;
                mouseY = e.Y;
                isPressed = true;
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            isPressed = false;
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            if (isPressed)
            {
                angleY += (e.X - mouseX) * 0.5f;
                angleX += (e.Y - mouseY) * 0.5f;

                mouseX = e.X;
                mouseY = e.Y;
            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            float minScale = 0.005f;
            float maxScale = 10f;

            modelScale *= e.Delta > 0 ? 1.1f : 1/1.1f;
            modelScale = MathHelper.Clamp(modelScale, minScale, maxScale);
        }

        public string ShowOpenFileDialog()
        {
            string selectedPath = null;

            var thread = new Thread(() =>
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Filter = "OBJ files (*.obj)|*.obj";
                    dialog.Title = "Select a 3D Model";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedPath = dialog.FileName;
                    }
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return selectedPath;
        }
    }

    public class Vertex
    {
        public Vector3 Position;
        public Vector2 TexCoord;
        public Vector3 Normal;

        public Vertex(Vector3 pos)
        {
            Position = pos;
            TexCoord = Vector2.Zero;
            Normal = Vector3.Zero;
        }
    }

    public class Face
    {
        public int[] VertexIndices;
        public string MaterialName;
    }

    public class Material
    {
        public string Name;
        public Vector3 Ambient = new(0.2f, 0.2f, 0.2f);
        public Vector3 Diffuse = new(0.8f, 0.8f, 0.8f);
        public Vector3 Specular = new(1.0f, 1.0f, 1.0f);

        public string DiffuseTexturePath;
        public int DiffuseTextureID;

        public string AmbientTexturePath;
        public int AmbientTextureID;

        public string BumpTexturePath;
        public int BumpTextureID;
    }

    public class ObjModel
    {
        public List<Vertex> Vertices = new();
        public List<Vector2> TexCoords = new();
        public List<Vector3> Normals = new();
        public List<Face> Faces = new();
        public Dictionary<string, Material> Materials = new();
        public string CurrentMaterial = null;

        public ObjModel Load(string path)
        {
            var model = new ObjModel();
            var lines = File.ReadLines(path);

            foreach (var rawLine in lines)
            {
                string line = rawLine.Replace(',', '.');
                var parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                ProcessLine(parts, model, path);
            }

            GenerateNormalsIfMissing(model);
            return model;
        }

        private void ProcessLine(string[] parts, ObjModel model, string path)
        {
            switch (parts[0])
            {
                case "v":
                    model.Vertices.Add(new Vertex(new Vector3(
                        float.Parse(parts[1], CultureInfo.InvariantCulture),
                        float.Parse(parts[2], CultureInfo.InvariantCulture),
                        float.Parse(parts[3], CultureInfo.InvariantCulture))));
                    break;

                case "vt":
                    model.TexCoords.Add(new Vector2(
                        float.Parse(parts[1], CultureInfo.InvariantCulture),
                        float.Parse(parts[2], CultureInfo.InvariantCulture)));
                    break;

                case "vn":
                    model.Normals.Add(new Vector3(
                        float.Parse(parts[1], CultureInfo.InvariantCulture),
                        float.Parse(parts[2], CultureInfo.InvariantCulture),
                        float.Parse(parts[3], CultureInfo.InvariantCulture)));
                    break;

                case "f":
                    ProcessFace(parts, model);
                    break;

                case "usemtl":
                    model.CurrentMaterial = parts[1];
                    break;

                case "mtllib":
                    var mtlPath = Path.Combine(Path.GetDirectoryName(path), parts[1]);
                    LoadMtl(mtlPath, model);
                    break;
            }
        }

        private void ProcessFace(string[] parts, ObjModel model)
        {
            var face = new Face();
            var vIndices = new List<int>();

            for (int i = 1; i < parts.Length; i++)
            {
                var tokens = parts[i].Split('/');
                int vIdx = int.Parse(tokens[0]) - 1;
                vIndices.Add(vIdx);

                var vertex = model.Vertices[vIdx];

                if (tokens.Length > 1 && !string.IsNullOrEmpty(tokens[1]))
                {
                    int tIdx = int.Parse(tokens[1]) - 1;
                    if (tIdx >= 0 && tIdx < model.TexCoords.Count)
                        vertex.TexCoord = model.TexCoords[tIdx];
                }

                if (tokens.Length > 2 && !string.IsNullOrEmpty(tokens[2]))
                {
                    int nIdx = int.Parse(tokens[2]) - 1;
                    if (nIdx >= 0 && nIdx < model.Normals.Count)
                        vertex.Normal = model.Normals[nIdx];
                }

                model.Vertices[vIdx] = vertex;
            }

            face.VertexIndices = vIndices.ToArray();
            face.MaterialName = model.CurrentMaterial;
            model.Faces.Add(face);
        }

        public void LoadMtl(string mtlPath, ObjModel model)
        {
            if (!File.Exists(mtlPath)) return;

            var lines = File.ReadAllLines(mtlPath);
            Material current = null;

            foreach (var raw in lines)
            {
                var line = raw.Trim();
                if (line == "" || line.StartsWith("#")) continue;

                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2) continue;

                switch (parts[0])
                {
                    case "newmtl":
                        if (current != null && !string.IsNullOrEmpty(current.Name))
                            model.Materials[current.Name] = current;

                        current = new Material { Name = parts[1] };
                        break;

                    case "Ka": current.Ambient = ParseVec3(parts); break;
                    case "Kd": current.Diffuse = ParseVec3(parts); break;
                    case "Ks": current.Specular = ParseVec3(parts); break;

                    case "map_Kd":
                        current.DiffuseTexturePath = Path.Combine(Path.GetDirectoryName(mtlPath), parts[1]);
                        current.DiffuseTextureID = TextureLoader.LoadTexture(current.DiffuseTexturePath);
                        break;

                    case "map_Ka":
                        current.AmbientTexturePath = Path.Combine(Path.GetDirectoryName(mtlPath), parts[1]);
                        current.AmbientTextureID = TextureLoader.LoadTexture(current.AmbientTexturePath);
                        break;

                    case "map_bump":
                    case "bump":
                        current.BumpTexturePath = Path.Combine(Path.GetDirectoryName(mtlPath), parts[1]);
                        current.BumpTextureID = TextureLoader.LoadTexture(current.BumpTexturePath);
                        break;
                }
            }

            if (current != null && !string.IsNullOrEmpty(current.Name))
                model.Materials[current.Name] = current;
        }

        private Vector3 ParseVec3(string[] parts)
        {
            return new Vector3(
                float.Parse(parts[1], CultureInfo.InvariantCulture),
                float.Parse(parts[2], CultureInfo.InvariantCulture),
                float.Parse(parts[3], CultureInfo.InvariantCulture));
        }

        private void GenerateNormalsIfMissing(ObjModel model)
        {
            if (model.Vertices.Count == 0 || model.Vertices[0].Normal != Vector3.Zero)
                return;

            var tempNormals = new Vector3[model.Vertices.Count];

            foreach (var face in model.Faces)
            {
                var v0 = model.Vertices[face.VertexIndices[0]].Position;
                var v1 = model.Vertices[face.VertexIndices[1]].Position;
                var v2 = model.Vertices[face.VertexIndices[2]].Position;

                var edge1 = v1 - v0;
                var edge2 = v2 - v0;
                var faceNormal = Vector3.Cross(edge1, edge2).Normalized();

                foreach (var idx in face.VertexIndices)
                {
                    tempNormals[idx] += faceNormal;
                }
            }

            for (int i = 0; i < model.Vertices.Count; i++)
            {
                var n = tempNormals[i];
                model.Vertices[i].Normal = n.Length > 0 ? n.Normalized() : new Vector3(0, 1, 0);
            }
        }
    }

    public static class TextureLoader
    {
        public static int LoadTexture(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Texture file not found: " + filePath);
                return 0;
            }

            using var bitmap = new Bitmap(filePath);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            var data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            int textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureID);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return textureID;
        }
    }
}