namespace Module_5._5;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnResult_Click(object sender, EventArgs e)
    {
        double.TryParse(numberOne.Text, out double numOne);
        double.TryParse(numberTwo.Text, out double numTwo);
        var sum = numOne + numTwo;
        var sub = numOne - numTwo;
        var mult = numOne * numTwo;
        var div = numOne / numTwo;
        if (btnAdd.Checked)
        {
            result.Text = sum.ToString();
            lbOp.Text = "+";
        }
        if (btnSub.Checked)
        {
            result.Text = sub.ToString();
            lbOp.Text = "-";
        }
        if (btnMult.Checked)
        {
            result.Text = mult.ToString();
            lbOp.Text = "*";
        }
        if (btnDiv.Checked)
        {
            if (numTwo != 0)
            {
                result.Text = div.ToString();
                lbOp.Text = "/";
            }
            else Console.WriteLine("Нельзя делить на 0!");
        }

    }
}