using System;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Module_7
{
    public class Shader : IDisposable
    {
        public int Handle;

        public Shader(string vertexPath, string fragmentPath)
        {
            var vsSource = File.ReadAllText(vertexPath);
            var fsSource = File.ReadAllText(fragmentPath);

            int vs = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vs, vsSource);
            GL.CompileShader(vs);
            GL.GetShader(vs, ShaderParameter.CompileStatus, out int ok);
            if (ok == 0) Console.WriteLine("VS compile: " + GL.GetShaderInfoLog(vs));

            int fs = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fs, fsSource);
            GL.CompileShader(fs);
            GL.GetShader(fs, ShaderParameter.CompileStatus, out ok);
            if (ok == 0) Console.WriteLine("FS compile: " + GL.GetShaderInfoLog(fs));

            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vs);
            GL.AttachShader(Handle, fs);
            GL.LinkProgram(Handle);
            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out ok);
            if (ok == 0) Console.WriteLine("Link: " + GL.GetProgramInfoLog(Handle));

            GL.DetachShader(Handle, vs);
            GL.DetachShader(Handle, fs);
            GL.DeleteShader(vs);
            GL.DeleteShader(fs);
        }

        public void Use() => GL.UseProgram(Handle);

        public void SetMatrix4(string name, Matrix4 m)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (loc != -1) GL.UniformMatrix4(loc, false, ref m);
        }

        public void SetVector3(string name, Vector3 v)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (loc != -1) GL.Uniform3(loc, v);
        }

        public void SetInt(string name, int v)
        {
            int loc = GL.GetUniformLocation(Handle, name);
            if (loc != -1) GL.Uniform1(loc, v);
        }

        public void Dispose()
        {
            if (Handle != 0) { GL.DeleteProgram(Handle); Handle = 0; }
        }
    }
}
