using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Module_8
{
    public partial class Form1 : Form
    {
        private double operandA, operandB;
        private bool resultShown = false;
        private Operation selectedOperation;
        private Dictionary<string, Operation> operations = new();

        public Form1()
        {
            InitializeComponent();
            // Инициализация операций
            operations.Add("btn_Add", new AddOperation());
            operations.Add("btn_Sub", new SubOperation());
            operations.Add("btn_Mult", new MultOperation());
            operations.Add("btn_Div", new DivOperation());
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Если была нажата кнопка результата
            if (resultShown)
            {
                textBox.Text = ""; // Очищается поле вывода
                resultShown = false;
            }

            // Только одну операцию за раз 
            if (operations.ContainsKey(btn.Name))
            {
                if (selectedOperation != null)
                    return; // операция уже выбрана — игнорируем

                selectedOperation = operations[btn.Name];
                textBox.Text += " " + btn.Text + " ";
            }
            else
            {
                textBox.Text += btn.Text;
            }
        }
        private void btn_Result_Click(object sender, EventArgs e)
        {
            // Получение операндов
            var parts = textBox.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3 || selectedOperation == null)
                return;

            if (double.TryParse(parts[0], out operandA) && double.TryParse(parts[2], out operandB))
            {
                try
                {
                    // Выполнение выбранной операции
                    double result = selectedOperation.Execute(operandA, operandB);
                    textBox.Text = result.ToString(CultureInfo.InvariantCulture);
                }
                catch (DivideByZeroException ex)
                {
                    textBox.Text = "Ошибка: " + ex.Message;
                }
            }
            resultShown = true;
            selectedOperation = null;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            operandA = operandB = 0;
            selectedOperation = null;
            resultShown = false;
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
        }
    }

    // Абстрактный класс операций
    public abstract class Operation
    {
        public abstract double Execute(double a, double b);
    }

    public class AddOperation : Operation
    {
        public override double Execute(double a, double b) => a + b;
    }

    public class SubOperation : Operation
    {
        public override double Execute(double a, double b) => a - b;
    }

    public class MultOperation : Operation
    {
        public override double Execute(double a, double b) => a * b;
    }

    public class DivOperation : Operation
    {
        public override double Execute(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль невозможно");
            return a / b;
        }
    }
}
