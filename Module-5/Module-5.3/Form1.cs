using System.Collections.Generic;
namespace Module_5._3;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        string task = textBox1.Text.Trim();
        if (!string.IsNullOrEmpty(task))
        {
            checkedListBox1.Items.Add(task);
            textBox1.Clear();
            textBox1.Focus();
        }
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
        // Удаляем в обратном порядке чтобы индексы не сдвигались
        for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)
        {
            if (checkedListBox1.GetItemChecked(i))
            {
                checkedListBox1.Items.RemoveAt(i);
            }
        }
    }

}