namespace Module_6;

public partial class UpdateDialog : Form
{
    public string UpdateText => textBox1.Text;
    public UpdateDialog()
    {
        InitializeComponent();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK; 
        this.Close();
    }
}