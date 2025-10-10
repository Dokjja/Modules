using System;
using System.Drawing;
using System.Windows.Forms;

namespace Module_5._4
{
    public partial class Form1 : Form
    {
        private float scale = 1.0f;
        private Image originalImage;
        public Form1()
        {
            InitializeComponent();
            InitializeContainer();
        }
        private void InitializeContainer()
        {
            panel1.AutoScroll = false; // отключаем прокрутку
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = new Point(0, 0);
            panel1.Controls.Add(pictureBox1);
            panel1.MouseWheel += Panel1_MouseWheel;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG Images (*.png)|*.png|JPG Images (*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                originalImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = originalImage;
                pictureBox1.Size = new Size(originalImage.Width, originalImage.Height);
                CenterImageInPanel();

                scale = 1.0f;
            }
        }
        private void Panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (originalImage == null || Control.ModifierKeys != Keys.Control)
                return;

            scale *= e.Delta > 0 ? 1.1f : 0.9f;
            scale = Math.Clamp(scale, 0.1f, 10f);

            int newWidth = (int)(originalImage.Width * scale);
            int newHeight = (int)(originalImage.Height * scale);

            pictureBox1.Size = new Size(newWidth, newHeight);
            CenterImageInPanel();

            ((HandledMouseEventArgs)e).Handled = true;
        }
        private void CenterImageInPanel()
        {
            if (pictureBox1.Image == null) return;

            int x = (panel1.Width - pictureBox1.Width) / 2;
            int y = (panel1.Height - pictureBox1.Height) / 2;

            pictureBox1.Location = new Point(x, y);
        }
    }
}
