using System.Globalization;

namespace Module_7;
/*
 * Написать защиту от деления на 0
 * Сделать чтобы можно было делать только одну операцию за раз
 */
public partial class Form1 : Form
{
    private double Result;
    private bool ResultShown = false;
    private int opNum = 0;
    private double operandA, operandB = 0;
    public Form1()
    {
        InitializeComponent();
    }

    private void btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (ResultShown)
        {
            textBox.Text = "";
            ResultShown = false;
        }
        textBox.Text += btn.Text + @" ";
        switch (btn.Name)
        {
            case "btn_Add":
                opNum = 0;
                break;
            case "btn_Sub":
                opNum = 1;
                break;
            case "btn_Mult":
                opNum = 2;
                break;
            case "btn_Div":
                opNum = 3;
                break;
            case "btn_Percent":
                opNum = 4;
                break;
            default:
                break;
        }
    }

    private void Add(double a, double b)
    {
        Result = a + b;
        textBox.Text = Result.ToString(CultureInfo.InvariantCulture);
    }

    private void Sub(double a, double b)
    {
        Result = a - b;
        textBox.Text = Result.ToString(CultureInfo.InvariantCulture);
    }

    private void Mult(double a, double b)
    {
        Result = a * b;
        textBox.Text = Result.ToString(CultureInfo.InvariantCulture);
    }

    private void Div(double a, double b)
    {
        Result = a / b;
        textBox.Text = Result.ToString(CultureInfo.InvariantCulture);
    }

    
    private void btn_Result_Click(object sender, EventArgs e)
    {
        var text = textBox.Text.Split(' ');
        try
        {
            double.TryParse(text[0], out operandA);
            double.TryParse(text[2], out operandB);    
        }
        catch{}
        switch (opNum)
        {
            case 0:
                Add(operandA, operandB);
                break;
            case 1:
                Sub(operandA, operandB);
                break;
            case 2:
                Mult(operandA, operandB);
                break;
            case 3:
                Div(operandA, operandB);
                break;
        }
        ResultShown = true;
    }
}

public class Operations
{
    
    
}
