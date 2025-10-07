namespace Module_5._1;

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
        btnLine = new System.Windows.Forms.Button();
        btnRect = new System.Windows.Forms.Button();
        btnCircle = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // btnLine
        // 
        btnLine.Font = new System.Drawing.Font("ProFont IIx Nerd Font Propo", 13.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnLine.Location = new System.Drawing.Point(3, 2);
        btnLine.Name = "btnLine";
        btnLine.Size = new System.Drawing.Size(39, 34);
        btnLine.TabIndex = 0;
        btnLine.Text = "—";
        btnLine.UseVisualStyleBackColor = true;
        btnLine.Click += btnLine_Click;
        // 
        // btnRect
        // 
        btnRect.Font = new System.Drawing.Font("ProFont IIx Nerd Font Propo", 13.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnRect.Location = new System.Drawing.Point(48, 2);
        btnRect.Name = "btnRect";
        btnRect.Size = new System.Drawing.Size(39, 34);
        btnRect.TabIndex = 0;
        btnRect.Text = "▭";
        btnRect.UseVisualStyleBackColor = true;
        btnRect.Click += btnRect_Click;
        // 
        // btnCircle
        // 
        btnCircle.Font = new System.Drawing.Font("ProFont IIx Nerd Font Propo", 13.799999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnCircle.Location = new System.Drawing.Point(93, 2);
        btnCircle.Name = "btnCircle";
        btnCircle.Size = new System.Drawing.Size(39, 34);
        btnCircle.TabIndex = 0;
        btnCircle.Text = "○";
        btnCircle.UseVisualStyleBackColor = true;
        btnCircle.Click += btnCircle_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(788, 645);
        Controls.Add(btnCircle);
        Controls.Add(btnRect);
        Controls.Add(btnLine);
        DoubleBuffered = true;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        Text = "Form1";
        Paint += Form_Paint;
        MouseDown += Form_MouseDown;
        MouseUp += Form_MouseUp;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnLine;
    private System.Windows.Forms.Button btnCircle;

    private System.Windows.Forms.Button btnRect;

    #endregion
}