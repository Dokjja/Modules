namespace Module_5._2;

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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnOpen = new Button();
        saveFileDialog1 = new SaveFileDialog();
        openFileDialog1 = new OpenFileDialog();
        btnSave = new Button();
        textBox1 = new TextBox();
        SuspendLayout();
        // 
        // btnOpen
        // 
        btnOpen.Location = new Point(12, 12);
        btnOpen.Name = "btnOpen";
        btnOpen.Size = new Size(57, 35);
        btnOpen.TabIndex = 1;
        btnOpen.Text = "Open";
        btnOpen.UseVisualStyleBackColor = true;
        btnOpen.Click += btnOpen_Click;
        // 
        // openFileDialog1
        // 
        openFileDialog1.FileName = "openFileDialog1";
        // 
        // btnSave
        // 
        btnSave.Location = new Point(75, 12);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(57, 35);
        btnSave.TabIndex = 1;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox1.Location = new Point(-2, 53);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ScrollBars = ScrollBars.Both;
        textBox1.Size = new Size(804, 404);
        textBox1.TabIndex = 2;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(textBox1);
        Controls.Add(btnSave);
        Controls.Add(btnOpen);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }


    private System.Windows.Forms.Button btnOpen;

    
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;

    #endregion

    private TextBox textBox1;
}