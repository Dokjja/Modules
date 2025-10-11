using System.ComponentModel;

namespace Module_6;

partial class UpdateDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        btnUpdate = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new System.Drawing.Point(96, 130);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new System.Drawing.Size(112, 26);
        btnUpdate.TabIndex = 0;
        btnUpdate.Text = "Изменить";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(42, 78);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(235, 27);
        textBox1.TabIndex = 1;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(71, 45);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(186, 30);
        label1.TabIndex = 2;
        label1.Text = "Введите новую задачу";
        // 
        // UpdateDialog
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(317, 253);
        Controls.Add(label1);
        Controls.Add(textBox1);
        Controls.Add(btnUpdate);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        Text = "UpdateDialog";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;

    #endregion
}