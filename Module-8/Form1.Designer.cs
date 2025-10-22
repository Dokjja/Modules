namespace Module_8;

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
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
        btn_Back = new System.Windows.Forms.Button();
        btn_Clear = new System.Windows.Forms.Button();
        btn_Percent = new System.Windows.Forms.Button();
        btn_Add = new System.Windows.Forms.Button();
        btn_Zero = new System.Windows.Forms.Button();
        btn_Sub = new System.Windows.Forms.Button();
        btn_Nine = new System.Windows.Forms.Button();
        btn_Eight = new System.Windows.Forms.Button();
        btn_Seven = new System.Windows.Forms.Button();
        btn_Mult = new System.Windows.Forms.Button();
        btn_Six = new System.Windows.Forms.Button();
        btn_Five = new System.Windows.Forms.Button();
        btn_Four = new System.Windows.Forms.Button();
        btn_Div = new System.Windows.Forms.Button();
        btn_Three = new System.Windows.Forms.Button();
        btn_Two = new System.Windows.Forms.Button();
        btn_Result = new System.Windows.Forms.Button();
        btn_One = new System.Windows.Forms.Button();
        btn_Column = new System.Windows.Forms.Button();
        btn_DoubleZero = new System.Windows.Forms.Button();
        textBox = new System.Windows.Forms.RichTextBox();
        tableLayoutPanel1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
        tableLayoutPanel1.Controls.Add(textBox, 0, 0);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.891891F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.10811F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new System.Drawing.Size(447, 618);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 4;
        tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        tableLayoutPanel2.Controls.Add(btn_Back, 2, 0);
        tableLayoutPanel2.Controls.Add(btn_Clear, 1, 0);
        tableLayoutPanel2.Controls.Add(btn_Percent, 0, 0);
        tableLayoutPanel2.Controls.Add(btn_Add, 3, 4);
        tableLayoutPanel2.Controls.Add(btn_Zero, 1, 4);
        tableLayoutPanel2.Controls.Add(btn_Sub, 3, 3);
        tableLayoutPanel2.Controls.Add(btn_Nine, 2, 3);
        tableLayoutPanel2.Controls.Add(btn_Eight, 1, 3);
        tableLayoutPanel2.Controls.Add(btn_Seven, 0, 3);
        tableLayoutPanel2.Controls.Add(btn_Mult, 3, 2);
        tableLayoutPanel2.Controls.Add(btn_Six, 2, 2);
        tableLayoutPanel2.Controls.Add(btn_Five, 1, 2);
        tableLayoutPanel2.Controls.Add(btn_Four, 0, 2);
        tableLayoutPanel2.Controls.Add(btn_Div, 3, 1);
        tableLayoutPanel2.Controls.Add(btn_Three, 2, 1);
        tableLayoutPanel2.Controls.Add(btn_Two, 1, 1);
        tableLayoutPanel2.Controls.Add(btn_Result, 3, 0);
        tableLayoutPanel2.Controls.Add(btn_One, 0, 1);
        tableLayoutPanel2.Controls.Add(btn_Column, 2, 4);
        tableLayoutPanel2.Controls.Add(btn_DoubleZero, 0, 4);
        tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel2.Location = new System.Drawing.Point(3, 169);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 5;
        tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        tableLayoutPanel2.Size = new System.Drawing.Size(441, 446);
        tableLayoutPanel2.TabIndex = 0;
        // 
        // btn_Back
        // 
        btn_Back.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Back.Location = new System.Drawing.Point(221, 1);
        btn_Back.Margin = new System.Windows.Forms.Padding(1);
        btn_Back.Name = "btn_Back";
        btn_Back.Size = new System.Drawing.Size(108, 87);
        btn_Back.TabIndex = 24;
        btn_Back.Text = "Back";
        btn_Back.UseMnemonic = false;
        btn_Back.UseVisualStyleBackColor = true;
        btn_Back.Click += btn_Back_Click;
        // 
        // btn_Clear
        // 
        btn_Clear.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Clear.Location = new System.Drawing.Point(111, 1);
        btn_Clear.Margin = new System.Windows.Forms.Padding(1);
        btn_Clear.Name = "btn_Clear";
        btn_Clear.Size = new System.Drawing.Size(108, 87);
        btn_Clear.TabIndex = 23;
        btn_Clear.Text = "Clear";
        btn_Clear.UseMnemonic = false;
        btn_Clear.UseVisualStyleBackColor = true;
        btn_Clear.Click += btn_Clear_Click;
        // 
        // btn_Percent
        // 
        btn_Percent.BackColor = System.Drawing.SystemColors.ActiveBorder;
        btn_Percent.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Percent.Location = new System.Drawing.Point(1, 1);
        btn_Percent.Margin = new System.Windows.Forms.Padding(1);
        btn_Percent.Name = "btn_Percent";
        btn_Percent.Size = new System.Drawing.Size(108, 87);
        btn_Percent.TabIndex = 22;
        btn_Percent.UseMnemonic = false;
        btn_Percent.UseVisualStyleBackColor = false;
        // 
        // btn_Add
        // 
        btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Add.Location = new System.Drawing.Point(331, 357);
        btn_Add.Margin = new System.Windows.Forms.Padding(1);
        btn_Add.Name = "btn_Add";
        btn_Add.Size = new System.Drawing.Size(109, 88);
        btn_Add.TabIndex = 19;
        btn_Add.Text = "+";
        btn_Add.UseMnemonic = false;
        btn_Add.UseVisualStyleBackColor = true;
        btn_Add.Click += btn_Click;
        // 
        // btn_Zero
        // 
        btn_Zero.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Zero.Location = new System.Drawing.Point(111, 357);
        btn_Zero.Margin = new System.Windows.Forms.Padding(1);
        btn_Zero.Name = "btn_Zero";
        btn_Zero.Size = new System.Drawing.Size(108, 88);
        btn_Zero.TabIndex = 17;
        btn_Zero.Text = "0";
        btn_Zero.UseMnemonic = false;
        btn_Zero.UseVisualStyleBackColor = true;
        btn_Zero.Click += btn_Click;
        // 
        // btn_Sub
        // 
        btn_Sub.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Sub.Location = new System.Drawing.Point(331, 268);
        btn_Sub.Margin = new System.Windows.Forms.Padding(1);
        btn_Sub.Name = "btn_Sub";
        btn_Sub.Size = new System.Drawing.Size(109, 87);
        btn_Sub.TabIndex = 15;
        btn_Sub.Text = "-";
        btn_Sub.UseMnemonic = false;
        btn_Sub.UseVisualStyleBackColor = true;
        btn_Sub.Click += btn_Click;
        // 
        // btn_Nine
        // 
        btn_Nine.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Nine.Location = new System.Drawing.Point(221, 268);
        btn_Nine.Margin = new System.Windows.Forms.Padding(1);
        btn_Nine.Name = "btn_Nine";
        btn_Nine.Size = new System.Drawing.Size(108, 87);
        btn_Nine.TabIndex = 14;
        btn_Nine.Text = "9";
        btn_Nine.UseMnemonic = false;
        btn_Nine.UseVisualStyleBackColor = true;
        btn_Nine.Click += btn_Click;
        // 
        // btn_Eight
        // 
        btn_Eight.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Eight.Location = new System.Drawing.Point(111, 268);
        btn_Eight.Margin = new System.Windows.Forms.Padding(1);
        btn_Eight.Name = "btn_Eight";
        btn_Eight.Size = new System.Drawing.Size(108, 87);
        btn_Eight.TabIndex = 13;
        btn_Eight.Text = "8";
        btn_Eight.UseMnemonic = false;
        btn_Eight.UseVisualStyleBackColor = true;
        btn_Eight.Click += btn_Click;
        // 
        // btn_Seven
        // 
        btn_Seven.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Seven.Location = new System.Drawing.Point(1, 268);
        btn_Seven.Margin = new System.Windows.Forms.Padding(1);
        btn_Seven.Name = "btn_Seven";
        btn_Seven.Size = new System.Drawing.Size(108, 87);
        btn_Seven.TabIndex = 12;
        btn_Seven.Text = "7";
        btn_Seven.UseMnemonic = false;
        btn_Seven.UseVisualStyleBackColor = true;
        btn_Seven.Click += btn_Click;
        // 
        // btn_Mult
        // 
        btn_Mult.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Mult.Location = new System.Drawing.Point(331, 179);
        btn_Mult.Margin = new System.Windows.Forms.Padding(1);
        btn_Mult.Name = "btn_Mult";
        btn_Mult.Size = new System.Drawing.Size(109, 87);
        btn_Mult.TabIndex = 11;
        btn_Mult.Text = "*";
        btn_Mult.UseMnemonic = false;
        btn_Mult.UseVisualStyleBackColor = true;
        btn_Mult.Click += btn_Click;
        // 
        // btn_Six
        // 
        btn_Six.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Six.Location = new System.Drawing.Point(221, 179);
        btn_Six.Margin = new System.Windows.Forms.Padding(1);
        btn_Six.Name = "btn_Six";
        btn_Six.Size = new System.Drawing.Size(108, 87);
        btn_Six.TabIndex = 10;
        btn_Six.Text = "6";
        btn_Six.UseMnemonic = false;
        btn_Six.UseVisualStyleBackColor = true;
        btn_Six.Click += btn_Click;
        // 
        // btn_Five
        // 
        btn_Five.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Five.Location = new System.Drawing.Point(111, 179);
        btn_Five.Margin = new System.Windows.Forms.Padding(1);
        btn_Five.Name = "btn_Five";
        btn_Five.Size = new System.Drawing.Size(108, 87);
        btn_Five.TabIndex = 9;
        btn_Five.Text = "5";
        btn_Five.UseMnemonic = false;
        btn_Five.UseVisualStyleBackColor = true;
        btn_Five.Click += btn_Click;
        // 
        // btn_Four
        // 
        btn_Four.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Four.Location = new System.Drawing.Point(1, 179);
        btn_Four.Margin = new System.Windows.Forms.Padding(1);
        btn_Four.Name = "btn_Four";
        btn_Four.Size = new System.Drawing.Size(108, 87);
        btn_Four.TabIndex = 8;
        btn_Four.Text = "4";
        btn_Four.UseMnemonic = false;
        btn_Four.UseVisualStyleBackColor = true;
        btn_Four.Click += btn_Click;
        // 
        // btn_Div
        // 
        btn_Div.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Div.Location = new System.Drawing.Point(331, 90);
        btn_Div.Margin = new System.Windows.Forms.Padding(1);
        btn_Div.Name = "btn_Div";
        btn_Div.Size = new System.Drawing.Size(109, 87);
        btn_Div.TabIndex = 7;
        btn_Div.Text = "/";
        btn_Div.UseMnemonic = false;
        btn_Div.UseVisualStyleBackColor = true;
        btn_Div.Click += btn_Click;
        // 
        // btn_Three
        // 
        btn_Three.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Three.Location = new System.Drawing.Point(221, 90);
        btn_Three.Margin = new System.Windows.Forms.Padding(1);
        btn_Three.Name = "btn_Three";
        btn_Three.Size = new System.Drawing.Size(108, 87);
        btn_Three.TabIndex = 6;
        btn_Three.Text = "3";
        btn_Three.UseMnemonic = false;
        btn_Three.UseVisualStyleBackColor = true;
        btn_Three.Click += btn_Click;
        // 
        // btn_Two
        // 
        btn_Two.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Two.Location = new System.Drawing.Point(111, 90);
        btn_Two.Margin = new System.Windows.Forms.Padding(1);
        btn_Two.Name = "btn_Two";
        btn_Two.Size = new System.Drawing.Size(108, 87);
        btn_Two.TabIndex = 5;
        btn_Two.Text = "2";
        btn_Two.UseMnemonic = false;
        btn_Two.UseVisualStyleBackColor = true;
        btn_Two.Click += btn_Click;
        // 
        // btn_Result
        // 
        btn_Result.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Result.Location = new System.Drawing.Point(331, 1);
        btn_Result.Margin = new System.Windows.Forms.Padding(1);
        btn_Result.Name = "btn_Result";
        btn_Result.Size = new System.Drawing.Size(109, 87);
        btn_Result.TabIndex = 4;
        btn_Result.Text = "=";
        btn_Result.UseMnemonic = false;
        btn_Result.UseVisualStyleBackColor = true;
        btn_Result.Click += btn_Result_Click;
        // 
        // btn_One
        // 
        btn_One.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_One.Location = new System.Drawing.Point(1, 90);
        btn_One.Margin = new System.Windows.Forms.Padding(1);
        btn_One.Name = "btn_One";
        btn_One.Size = new System.Drawing.Size(108, 87);
        btn_One.TabIndex = 0;
        btn_One.Text = "1";
        btn_One.UseMnemonic = false;
        btn_One.UseVisualStyleBackColor = true;
        btn_One.Click += btn_Click;
        // 
        // btn_Column
        // 
        btn_Column.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_Column.Location = new System.Drawing.Point(221, 357);
        btn_Column.Margin = new System.Windows.Forms.Padding(1);
        btn_Column.Name = "btn_Column";
        btn_Column.Size = new System.Drawing.Size(108, 88);
        btn_Column.TabIndex = 20;
        btn_Column.Text = ",";
        btn_Column.UseVisualStyleBackColor = true;
        btn_Column.Click += btn_Click;
        // 
        // btn_DoubleZero
        // 
        btn_DoubleZero.Dock = System.Windows.Forms.DockStyle.Fill;
        btn_DoubleZero.Location = new System.Drawing.Point(1, 357);
        btn_DoubleZero.Margin = new System.Windows.Forms.Padding(1);
        btn_DoubleZero.Name = "btn_DoubleZero";
        btn_DoubleZero.Size = new System.Drawing.Size(108, 88);
        btn_DoubleZero.TabIndex = 21;
        btn_DoubleZero.Text = "00";
        btn_DoubleZero.UseVisualStyleBackColor = true;
        btn_DoubleZero.Click += btn_Click;
        // 
        // textBox
        // 
        textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        textBox.DetectUrls = false;
        textBox.Dock = System.Windows.Forms.DockStyle.Fill;
        textBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        textBox.Location = new System.Drawing.Point(5, 5);
        textBox.Margin = new System.Windows.Forms.Padding(5);
        textBox.Multiline = false;
        textBox.Name = "textBox";
        textBox.Size = new System.Drawing.Size(437, 156);
        textBox.TabIndex = 1;
        textBox.Text = "0";
        textBox.WordWrap = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(447, 618);
        Controls.Add(tableLayoutPanel1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Text = "Form1";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button btn_Add;
    private System.Windows.Forms.Button btn_Zero;
    private System.Windows.Forms.Button btn_Sub;
    private System.Windows.Forms.Button btn_Nine;
    private System.Windows.Forms.Button btn_Eight;
    private System.Windows.Forms.Button btn_Seven;
    private System.Windows.Forms.Button btn_Mult;
    private System.Windows.Forms.Button btn_Six;
    private System.Windows.Forms.Button btn_Five;
    private System.Windows.Forms.Button btn_Four;
    private System.Windows.Forms.Button btn_Div;
    private System.Windows.Forms.Button btn_Three;
    private System.Windows.Forms.Button btn_Two;
    private System.Windows.Forms.Button btn_Result;
    private System.Windows.Forms.Button btn_One;
    private System.Windows.Forms.Button btn_Column;
    private System.Windows.Forms.Button btn_DoubleZero;
    private System.Windows.Forms.Button btn_Back;
    private System.Windows.Forms.Button btn_Clear;
    private System.Windows.Forms.Button btn_Percent;
    private System.Windows.Forms.RichTextBox textBox;
}