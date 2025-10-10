namespace Module_5._5;

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
        btnAdd = new RadioButton();
        numberOne = new TextBox();
        btnResult = new Button();
        btnSub = new RadioButton();
        btnMult = new RadioButton();
        btnDiv = new RadioButton();
        lbOp = new Label();
        tableLayoutPanel1 = new TableLayoutPanel();
        numberTwo = new TextBox();
        lbEqual = new Label();
        result = new TextBox();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // btnAdd
        // 
        btnAdd.AutoSize = true;
        btnAdd.Dock = DockStyle.Fill;
        btnAdd.Location = new Point(3, 3);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(89, 32);
        btnAdd.TabIndex = 0;
        btnAdd.TabStop = true;
        btnAdd.Text = "+";
        btnAdd.UseVisualStyleBackColor = true;
        // 
        // numberOne
        // 
        numberOne.Location = new Point(44, 48);
        numberOne.Name = "numberOne";
        numberOne.Size = new Size(60, 27);
        numberOne.TabIndex = 1;
        // 
        // btnResult
        // 
        btnResult.Location = new Point(131, 92);
        btnResult.Name = "btnResult";
        btnResult.Size = new Size(94, 29);
        btnResult.TabIndex = 3;
        btnResult.Text = "Вычислить";
        btnResult.UseVisualStyleBackColor = true;
        btnResult.Click += btnResult_Click;
        // 
        // btnSub
        // 
        btnSub.AutoSize = true;
        btnSub.Dock = DockStyle.Fill;
        btnSub.Location = new Point(98, 3);
        btnSub.Name = "btnSub";
        btnSub.Size = new Size(89, 32);
        btnSub.TabIndex = 0;
        btnSub.TabStop = true;
        btnSub.Text = "-";
        btnSub.UseVisualStyleBackColor = true;
        // 
        // btnMult
        // 
        btnMult.AutoSize = true;
        btnMult.Dock = DockStyle.Fill;
        btnMult.Location = new Point(193, 3);
        btnMult.Name = "btnMult";
        btnMult.Size = new Size(89, 32);
        btnMult.TabIndex = 0;
        btnMult.TabStop = true;
        btnMult.Text = "*";
        btnMult.UseVisualStyleBackColor = true;
        // 
        // btnDiv
        // 
        btnDiv.AutoSize = true;
        btnDiv.Dock = DockStyle.Fill;
        btnDiv.Location = new Point(288, 3);
        btnDiv.Name = "btnDiv";
        btnDiv.Size = new Size(92, 32);
        btnDiv.TabIndex = 0;
        btnDiv.TabStop = true;
        btnDiv.Text = "/";
        btnDiv.UseVisualStyleBackColor = true;
        // 
        // lbOp
        // 
        lbOp.AutoSize = true;
        lbOp.Location = new Point(110, 48);
        lbOp.Name = "lbOp";
        lbOp.Size = new Size(19, 20);
        lbOp.TabIndex = 2;
        lbOp.Text = "+";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 4;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.Controls.Add(btnAdd, 0, 0);
        tableLayoutPanel1.Controls.Add(btnSub, 1, 0);
        tableLayoutPanel1.Controls.Add(btnMult, 2, 0);
        tableLayoutPanel1.Controls.Add(btnDiv, 3, 0);
        tableLayoutPanel1.Location = new Point(0, 145);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Size = new Size(383, 38);
        tableLayoutPanel1.TabIndex = 4;
        // 
        // numberTwo
        // 
        numberTwo.Location = new Point(135, 48);
        numberTwo.Name = "numberTwo";
        numberTwo.Size = new Size(60, 27);
        numberTwo.TabIndex = 1;
        // 
        // lbEqual
        // 
        lbEqual.AutoSize = true;
        lbEqual.Location = new Point(206, 48);
        lbEqual.Name = "lbEqual";
        lbEqual.Size = new Size(19, 20);
        lbEqual.TabIndex = 2;
        lbEqual.Text = "=";
        // 
        // result
        // 
        result.Location = new Point(239, 48);
        result.Name = "result";
        result.Size = new Size(60, 27);
        result.TabIndex = 1;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(346, 204);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(btnResult);
        Controls.Add(lbEqual);
        Controls.Add(lbOp);
        Controls.Add(result);
        Controls.Add(numberTwo);
        Controls.Add(numberOne);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        Text = "Form1";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RadioButton btnAdd;
    private TextBox numberOne;
    private Button btnResult;
    private RadioButton btnSub;
    private RadioButton btnMult;
    private RadioButton btnDiv;
    private Label lbOp;
    private TableLayoutPanel tableLayoutPanel1;
    private TextBox numberTwo;
    private Label lbEqual;
    private TextBox result;
}