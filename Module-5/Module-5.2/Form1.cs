namespace Module_5._2;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
            textBox1.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
            System.IO.File.WriteAllText(saveFileDialog.FileName, textBox1.Text);
    }
}
