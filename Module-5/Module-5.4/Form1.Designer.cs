namespace Module_5._4;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnOpen = new Button();
        openFileDialog1 = new OpenFileDialog();
        panel1 = new Panel();
        panel2 = new Panel();
        pictureBox1 = new PictureBox();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // btnOpen
        // 
        btnOpen.Location = new Point(12, 6);
        btnOpen.Name = "btnOpen";
        btnOpen.Size = new Size(94, 29);
        btnOpen.TabIndex = 1;
        btnOpen.Text = "Открыть";
        btnOpen.UseVisualStyleBackColor = true;
        btnOpen.Click += btnOpen_Click;
        // 
        // openFileDialog1
        // 
        openFileDialog1.FileName = "openFileDialog1";
        // 
        // panel1
        // 
        panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel1.AutoScroll = true;
        panel1.Controls.Add(panel2);
        panel1.Controls.Add(pictureBox1);
        panel1.Location = new Point(0, 41);
        panel1.Name = "panel1";
        panel1.Size = new Size(803, 409);
        panel1.TabIndex = 2;
        // 
        // panel2
        // 
        panel2.Location = new Point(734, 331);
        panel2.Name = "panel2";
        panel2.Size = new Size(8, 8);
        panel2.TabIndex = 1;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(0, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(125, 62);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(panel1);
        Controls.Add(btnOpen);
        DoubleBuffered = true;
        Name = "Form1";
        Text = "Form1";
        panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private Button btnOpen;
    private OpenFileDialog openFileDialog1;
    private Panel panel1;
    private PictureBox pictureBox1;
    private Panel panel2;
}