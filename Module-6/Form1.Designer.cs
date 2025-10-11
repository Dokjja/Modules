namespace Module_6;

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
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        listBox1 = new System.Windows.Forms.ListBox();
        toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.Location = new System.Drawing.Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(button1);
        splitContainer1.Panel1.Controls.Add(textBox1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(listBox1);
        splitContainer1.Size = new System.Drawing.Size(887, 464);
        splitContainer1.SplitterDistance = 420;
        splitContainer1.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(163, 198);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(98, 36);
        button1.TabIndex = 1;
        button1.Text = "Добавить";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(46, 119);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(328, 61);
        textBox1.TabIndex = 0;
        // 
        // listBox1
        // 
        listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        listBox1.FormattingEnabled = true;
        listBox1.Location = new System.Drawing.Point(0, 0);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(463, 464);
        listBox1.TabIndex = 0;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem3
        // 
        toolStripMenuItem3.Name = "toolStripMenuItem3";
        toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem4
        // 
        toolStripMenuItem4.Name = "toolStripMenuItem4";
        toolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem5
        // 
        toolStripMenuItem5.Name = "toolStripMenuItem5";
        toolStripMenuItem5.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem6
        // 
        toolStripMenuItem6.Name = "toolStripMenuItem6";
        toolStripMenuItem6.Size = new System.Drawing.Size(32, 19);
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(887, 464);
        Controls.Add(splitContainer1);
        Text = "Form1";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TextBox textBox1;

    #endregion
}