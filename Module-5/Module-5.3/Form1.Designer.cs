namespace Module_5._3;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        textBox1 = new TextBox();
        btnAdd = new Button();
        checkedListBox1 = new CheckedListBox();
        btnDel = new Button();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
        textBox1.Location = new Point(56, 12);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(318, 30);
        textBox1.TabIndex = 0;
        textBox1.Text = "Введите задачу!";
        
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(70, 48);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(92, 33);
        btnAdd.TabIndex = 1;
        btnAdd.Text = "Добавить";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // checkedListBox1
        // 
        checkedListBox1.FormattingEnabled = true;
        checkedListBox1.Location = new Point(12, 85);
        checkedListBox1.Name = "checkedListBox1";
        checkedListBox1.Size = new Size(412, 444);
        checkedListBox1.TabIndex = 2;
        // 
        // btnDel
        // 
        btnDel.Location = new Point(257, 46);
        btnDel.Name = "btnDel";
        btnDel.Size = new Size(92, 33);
        btnDel.TabIndex = 1;
        btnDel.Text = "Удалить";
        btnDel.UseVisualStyleBackColor = true;
        btnDel.Click += btnDel_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        ClientSize = new Size(436, 552);
        Controls.Add(checkedListBox1);
        Controls.Add(btnDel);
        Controls.Add(btnAdd);
        Controls.Add(textBox1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox textBox1;
    private Button btnAdd;
    private CheckedListBox checkedListBox1;
    private Button btnDel;
}