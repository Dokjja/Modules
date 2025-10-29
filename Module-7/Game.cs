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
            // Создание и запуск главного игрового окна
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

            // Настройка базовых параметров OpenGL
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
            // Настройка параметров источника света
            float[] ambient = { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] diffuse = { 0.8f, 0.8f, 0.8f, 1.0f };
            float[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };

            GL.Light(LightName.Light0, LightParameter.Ambient, ambient);
            GL.Light(LightName.Light0, LightParameter.Diffuse, diffuse);
            GL.Light(LightName.Light0, LightParameter.Specular, specular);
        }

        private void SetupMaterials()
        {
            // Настройка параметров материала по умолчанию
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
            
            // Установка области отрисовки
            GL.Viewport(0, 0, Width, Height);

            // Настройка проекционной матрицы
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
            
            // Обработка выхода из приложения
            if (Keyboard.GetState().IsKeyDown(Key.Escape))
                Exit();
                
            // Обработка загрузки модели по нажатию W
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

            // Очистка буферов цвета и глубины
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SetupModelView();
            
            // Отрисовка модели, если она загружена
            if (model != null)
                DrawModel(model);

            SwapBuffers();
        }

        private void SetupModelView()
        {
            // Настройка матрицы модели-вида
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -5.0f);
            GL.Scale(modelScale, modelScale, modelScale);
            GL.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            GL.Rotate(angleY, 0.0f, 1.0f, 0.0f);
        }

        private void DrawModel(ObjModel model)
        {
            // Отрисовка всех полигонов модели
            foreach (var face in model.Faces)
            {
                // Проверка наличия материала и текстуры для текущего полигона
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
                
                // Отрисовка всех вершин полигона
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
            // Выбор типа примитива в зависимости от количества вершин
            switch (vertexCount)
            {
                case 3: GL.Begin(PrimitiveType.Triangles); break;
                case 4: GL.Begin(PrimitiveType.Quads); break;
                default: GL.Begin(PrimitiveType.Polygon); break;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            // Обработка нажатия левой кнопки мыши для начала вращения
            if (e.Button == MouseButton.Left)
            {
                mouseX = e.X;
                mouseY = e.Y;
                isPressed = true;
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            // Обработка отпускания кнопки мыши
            isPressed = false;
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            // Обработка вращения модели при зажатой левой кнопке мыши
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
            // Обработка масштабирования модели колесом мыши
            float minScale = 0.005f;
            float maxScale = 10f;

            modelScale *= e.Delta > 0 ? 1.1f : 1/1.1f;
            modelScale = MathHelper.Clamp(modelScale, minScale, maxScale);
        }

        public string ShowOpenFileDialog()
        {
            string selectedPath = null;

            // Создание диалога выбора файла в отдельном потоке
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
            
            // Чтение всех строк из OBJ файла
            var lines = File.ReadLines(path);

            // Обработка каждой строки файла
            foreach (var rawLine in lines)
            {
                // Замена запятых на точки для корректного парсинга чисел
                string line = rawLine.Replace(',', '.');
                var parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                ProcessLine(parts, model, path);
            }

            GenerateNormals(model);
            return model;
        }

        private void ProcessLine(string[] parts, ObjModel model, string path)
        {
            // Обработка различных типов строк в OBJ файле
            switch (parts[0])
            {
                case "v":
                    // Обработка вершин (координаты x, y, z)
                    model.Vertices.Add(new Vertex(new Vector3(
                        float.Parse(parts[1], CultureInfo.InvariantCulture),
                        float.Parse(parts[2], CultureInfo.InvariantCulture),
                        float.Parse(parts[3], CultureInfo.InvariantCulture))));
                    break;

                case "vt":
                    // Обработка текстурных координат (u, v)
                    model.TexCoords.Add(new Vector2(
                        float.Parse(parts[1], CultureInfo.InvariantCulture),
                        float.Parse(parts[2], CultureInfo.InvariantCulture)));
                    break;

                case "vn":
                    // Обработка нормалей (nx, ny, nz)
                    model.Normals.Add(new Vector3(
                        float.Parse(parts[1], CultureInfo.InvariantCulture),
                        float.Parse(parts[2], CultureInfo.InvariantCulture),
                        float.Parse(parts[3], CultureInfo.InvariantCulture)));
                    break;

                case "f":
                    // Обработка полигонов (индексы вершин)
                    ProcessFace(parts, model);
                    break;

                case "usemtl":
                    // Установка текущего материала
                    model.CurrentMaterial = parts[1];
                    break;

                case "mtllib":
                    // Загрузка файла материалов
                    var mtlPath = Path.Combine(Path.GetDirectoryName(path), parts[1]);
                    LoadMtl(mtlPath, model);
                    break;
            }
        }

        private void ProcessFace(string[] parts, ObjModel model)
        {
            var face = new Face();
            var vIndices = new List<int>();

            // Обработка всех вершин в определении полигона
            for (int i = 1; i < parts.Length; i++)
            {
                // Разбиение на вершины/текстуры/нормали
                var tokens = parts[i].Split('/');
                int vIdx = int.Parse(tokens[0]) - 1;
                vIndices.Add(vIdx);

                var vertex = model.Vertices[vIdx];

                // Обработка текстурных координат, если они есть
                if (tokens.Length > 1 && !string.IsNullOrEmpty(tokens[1]))
                {
                    int tIdx = int.Parse(tokens[1]) - 1;
                    if (tIdx >= 0 && tIdx < model.TexCoords.Count)
                        vertex.TexCoord = model.TexCoords[tIdx];
                }

                // Обработка нормалей, если они есть
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
            // Проверка существования файла материалов
            if (!File.Exists(mtlPath)) return;

            var lines = File.ReadAllLines(mtlPath);
            Material current = null;

            // Обработка всех строк в MTL файле
            foreach (var raw in lines)
            {
                var line = raw.Trim();
                // Пропуск пустых строк и комментариев
                if (line == "" || line.StartsWith("#")) continue;

                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2) continue;

                // Обработка различных параметров материала
                switch (parts[0])
                {
                    case "newmtl":
                        // Создание нового материала
                        if (current != null && !string.IsNullOrEmpty(current.Name))
                            model.Materials[current.Name] = current;

                        current = new Material { Name = parts[1] };
                        break;

                    case "Ka": current.Ambient = ParseVec3(parts); break;
                    case "Kd": current.Diffuse = ParseVec3(parts); break;
                    case "Ks": current.Specular = ParseVec3(parts); break;

                    case "map_Kd":
                        // Загрузка диффузной текстуры
                        current.DiffuseTexturePath = Path.Combine(Path.GetDirectoryName(mtlPath), parts[1]);
                        current.DiffuseTextureID = TextureLoader.LoadTexture(current.DiffuseTexturePath);
                        break;

                    case "map_Ka":
                        // Загрузка ambient текстуры
                        current.AmbientTexturePath = Path.Combine(Path.GetDirectoryName(mtlPath), parts[1]);
                        current.AmbientTextureID = TextureLoader.LoadTexture(current.AmbientTexturePath);
                        break;

                    case "map_bump":
                    case "bump":
                        // Загрузка bump текстуры
                        current.BumpTexturePath = Path.Combine(Path.GetDirectoryName(mtlPath), parts[1]);
                        current.BumpTextureID = TextureLoader.LoadTexture(current.BumpTexturePath);
                        break;
                }
            }

            // Добавление последнего материала в словарь
            if (current != null && !string.IsNullOrEmpty(current.Name))
                model.Materials[current.Name] = current;
        }

        private Vector3 ParseVec3(string[] parts)
        {
            // Парсинг вектора из трех компонентов
            return new Vector3(
                float.Parse(parts[1], CultureInfo.InvariantCulture),
                float.Parse(parts[2], CultureInfo.InvariantCulture),
                float.Parse(parts[3], CultureInfo.InvariantCulture));
        }

        private void GenerateNormals(ObjModel model)
        {
            // Проверка необходимости генерации нормалей
            if (model.Vertices.Count == 0 || model.Vertices[0].Normal != Vector3.Zero)
                return;

            var tempNormals = new Vector3[model.Vertices.Count];

            // Вычисление нормалей для каждого полигона
            foreach (var face in model.Faces)
            {
                var v0 = model.Vertices[face.VertexIndices[0]].Position;
                var v1 = model.Vertices[face.VertexIndices[1]].Position;
                var v2 = model.Vertices[face.VertexIndices[2]].Position;

                // Вычисление нормали полигона через векторное произведение
                var edge1 = v1 - v0;
                var edge2 = v2 - v0;
                var faceNormal = Vector3.Cross(edge1, edge2).Normalized();

                // Добавление нормали полигона ко всем его вершинам
                foreach (var idx in face.VertexIndices)
                {
                    tempNormals[idx] += faceNormal;
                }
            }

            // Нормализация результирующих нормалей вершин
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
            // Проверка существования файла текстуры
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Texture file not found: " + filePath);
                return 0;
            }

            using var bitmap = new Bitmap(filePath);
            // Отражение текстуры по Y (для корректного отображения в OpenGL)
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            // Блокировка битов изображения для чтения данных
            var data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            // Создание OpenGL текстуры
            int textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureID);

            // Загрузка данных изображения в текстуру
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);

            // Настройка параметров текстуры
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return textureID;
        }
    }
}