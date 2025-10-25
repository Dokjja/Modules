using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
namespace Module_7
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game window = new Game(800, 600, "3D Module Sim"))
            {
                window.Run();
            }

            
        }
    }
}