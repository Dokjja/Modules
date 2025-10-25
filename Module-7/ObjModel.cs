using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace Module_7
{
    public class ObjModel : IDisposable
    {
        // simple vertex container used while parsing
        public class TVertex
        {
            public Vector3 Position;
            public Vector2 TexCoord;
            public Vector3 Normal;

            public TVertex(Vector3 pos) { Position = pos; TexCoord = Vector2.Zero; Normal = Vector3.Zero; }
        }

        public class TMaterial
        {
            public string Name;
            public uint TextureID = 0;
            public Vector3 Ambient = Vector3.Zero;
            public Vector3 Diffuse = Vector3.One;
            public Vector3 Specular = Vector3.Zero;

            public TMaterial(string name) { Name = name; }
        }

        public static ObjModel Model; // optional global
        public List<TVertex> Vertices { get; } = new List<TVertex>();
        public record TFace(int[] VerticesIndices, string MaterialName);
        public List<TFace> Faces { get; } = new List<TFace>();
        private Dictionary<string, TMaterial> _materials = new();
        public IReadOnlyDictionary<string, TMaterial> Materials => _materials;
        public string CurrentMaterial { get; set; } = null;

        private readonly NumberFormatInfo _nfi;

        public ObjModel()
        {
            _nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            _nfi.NumberDecimalSeparator = ".";
        }

        uint LoadTexture(string fileName)
        {
            if (!File.Exists(fileName)) return 0;
            try
            {
                using var bitmap = new Bitmap(fileName);
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var data = bitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                uint tex = (uint)GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, tex);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                    bitmap.Width, bitmap.Height, 0,
                    PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                bitmap.UnlockBits(data);
                return tex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("LoadTexture error: " + ex.Message);
                return 0;
            }
        }

        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName)) return;
            Vertices.Clear();
            Faces.Clear();
            CurrentMaterial = null;

            var tempTex = new List<Vector2>();
            var tempNorm = new List<Vector3>();

            foreach (var raw in File.ReadAllLines(fileName))
            {
                var line = raw.Trim();
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;
                var parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 1) continue;
                switch (parts[0])
                {
                    case "v":
                        Vertices.Add(new TVertex(new Vector3(
                            float.Parse(parts[1], _nfi),
                            float.Parse(parts[2], _nfi),
                            float.Parse(parts[3], _nfi))));
                        break;
                    case "vt":
                        tempTex.Add(new Vector2(
                            float.Parse(parts[1], _nfi),
                            float.Parse(parts[2], _nfi)));
                        break;
                    case "vn":
                        tempNorm.Add(new Vector3(
                            float.Parse(parts[1], _nfi),
                            float.Parse(parts[2], _nfi),
                            float.Parse(parts[3], _nfi)));
                        break;
                    case "f":
                        // create face indices array (0-based)
                        var indices = new List<int>();
                        for (int i = 1; i < parts.Length; i++)
                        {
                            var comp = parts[i].Split('/');
                            int vi = int.Parse(comp[0]) - 1;
                            indices.Add(vi);

                            // set texcoord and normal for referenced vertex if available
                            if (comp.Length > 1 && !string.IsNullOrEmpty(comp[1]))
                            {
                                int ti = int.Parse(comp[1]) - 1;
                                if (ti >= 0 && ti < tempTex.Count)
                                    Vertices[vi].TexCoord = tempTex[ti];
                            }
                            if (comp.Length > 2 && !string.IsNullOrEmpty(comp[2]))
                            {
                                int ni = int.Parse(comp[2]) - 1;
                                if (ni >= 0 && ni < tempNorm.Count)
                                    Vertices[vi].Normal = tempNorm[ni];
                            }
                        }
                        Faces.Add(new TFace(indices.ToArray(), CurrentMaterial));
                        break;
                    case "usemtl":
                        if (parts.Length > 1) CurrentMaterial = parts[1];
                        break;
                    case "mtllib":
                        if (parts.Length > 1)
                        {
                            var mtlPath = Path.Combine(Path.GetDirectoryName(fileName), parts[1]);
                            if (File.Exists(mtlPath)) LoadMtl(mtlPath);
                        }
                        break;
                }
            }
        }
        
        public (Vector3 center, float radius) GetBoundingSphere()
        {
            if (Vertices.Count == 0) return (Vector3.Zero, 1);
            Vector3 min = Vertices[0].Position;
            Vector3 max = Vertices[0].Position;
            foreach (var v in Vertices)
            {
                min = Vector3.ComponentMin(min, v.Position);
                max = Vector3.ComponentMax(max, v.Position);
            }
            Vector3 center = (min + max) * 0.5f;
            float radius = (max - min).Length * 0.5f;
            return (center, radius);
        }

        public void LoadMtl(string fileName)
        {
            if (!File.Exists(fileName)) return;
            TMaterial current = null;
            foreach (var raw in File.ReadAllLines(fileName))
            {
                var line = raw.Trim();
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;
                var parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 1) continue;
                switch (parts[0])
                {
                    case "newmtl":
                        if (current != null && !_materials.ContainsKey(current.Name))
                            _materials[current.Name] = current;
                        current = new TMaterial(parts[1]);
                        break;
                    case "map_Kd":
                        if (current != null)
                        {
                            var texturePath = Path.Combine(Path.GetDirectoryName(fileName), parts[1]);
                            if (File.Exists(texturePath))
                                current.TextureID = LoadTexture(texturePath);
                        }
                        break;
                    case "Ka":
                        if (current != null)
                            current.Ambient = new Vector3(float.Parse(parts[1], _nfi), float.Parse(parts[2], _nfi), float.Parse(parts[3], _nfi));
                        break;
                    case "Kd":
                        if (current != null)
                            current.Diffuse = new Vector3(float.Parse(parts[1], _nfi), float.Parse(parts[2], _nfi), float.Parse(parts[3], _nfi));
                        break;
                    case "Ks":
                        if (current != null)
                            current.Specular = new Vector3(float.Parse(parts[1], _nfi), float.Parse(parts[2], _nfi), float.Parse(parts[3], _nfi));
                        break;
                }
            }
            if (current != null && !_materials.ContainsKey(current.Name))
                _materials[current.Name] = current;
        }

        // If normals are zero - generate smooth normals from faces
        public void GenerateNormals()
        {
            if (Vertices.Count == 0 || Faces.Count == 0) return;

            // initialize accumulation
            var accum = new Vector3[Vertices.Count];
            for (int i = 0; i < accum.Length; i++) accum[i] = Vector3.Zero;

            foreach (var face in Faces)
            {
                if (face.VerticesIndices.Length < 3) continue;
                var v0 = Vertices[face.VerticesIndices[0]].Position;
                for (int i = 1; i < face.VerticesIndices.Length - 1; i++)
                {
                    var v1 = Vertices[face.VerticesIndices[i]].Position;
                    var v2 = Vertices[face.VerticesIndices[i + 1]].Position;

                    var edge1 = v1 - v0;
                    var edge2 = v2 - v0;
                    var n = Vector3.Cross(edge1, edge2);
                    if (n.LengthSquared > 0) n = n.Normalized();

                    accum[face.VerticesIndices[0]] += n;
                    accum[face.VerticesIndices[i]] += n;
                    accum[face.VerticesIndices[i + 1]] += n;
                }
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                var a = accum[i];
                if (a.LengthSquared > 0)
                    Vertices[i].Normal = a.Normalized();
                else
                    Vertices[i].Normal = new Vector3(0, 1, 0);
            }
        }

        // Convert model to interleaved float array ordered by triangles (triangulate polygon faces via fan)
        public float[] ToFloatArray()
        {
            var list = new List<float>();
            foreach (var face in Faces)
            {
                var idx = face.VerticesIndices;
                if (idx.Length < 3) continue;
                // triangulate as fan: (0,i,i+1)
                for (int i = 1; i < idx.Length - 1; i++)
                {
                    int[] tri = new int[] { idx[0], idx[i], idx[i + 1] };
                    foreach (var vi in tri)
                    {
                        var v = Vertices[vi];
                        list.Add(v.Position.X);
                        list.Add(v.Position.Y);
                        list.Add(v.Position.Z);
                        list.Add(v.TexCoord.X);
                        list.Add(v.TexCoord.Y);
                        list.Add(v.Normal.X);
                        list.Add(v.Normal.Y);
                        list.Add(v.Normal.Z);
                    }
                }
            }
            return list.ToArray();
        }

        // dispose textures
        bool disposed = false;
        public void Dispose()
        {
            if (disposed) return;
            foreach (var m in _materials.Values)
            {
                if (m.TextureID != 0)
                {
                    GL.DeleteTexture((int)m.TextureID);
                    m.TextureID = 0;
                }
            }
            _materials.Clear();
            Vertices.Clear();
            Faces.Clear();
            disposed = true;
        }
    }
}
