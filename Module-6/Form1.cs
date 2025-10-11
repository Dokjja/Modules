using Microsoft.Data.Sqlite;
namespace Module_6;

public partial class Form1 : Form
{
    private string _selectedMenuItem;
    private ContextMenuStrip _contextMenuStrip1;
    private readonly string _path = "C:\\Users\\DKJ\\Desktop\\Praktika\\Modules\\Module-6\\TasksBD.db";
    private string _text;
    public Form1()
    {
        InitializeComponent();
        InitializeMenu();
    }
    // Инициализация контекстного меню
    private void InitializeMenu()
    {
        var toolStripMenuItem1 = new ToolStripMenuItem{Text = "Удалить"};
        toolStripMenuItem1.Click += toolStripMenuItem1_Click;
        var toolStripMenuItem2 = new ToolStripMenuItem { Text = "Изменить" };
        toolStripMenuItem2.Click += toolStripMenuItem2_Click;
        _contextMenuStrip1 = new ContextMenuStrip();
        _contextMenuStrip1.Items.AddRange(new ToolStripMenuItem[] {toolStripMenuItem1, toolStripMenuItem2});
        
        listBox1.MouseDown += listBox1_MouseDown;
    }
    // Работа со второй формой
    private void ShowUpdateDialog()
    {
        UpdateDialog updateDialog = new UpdateDialog();
        if (updateDialog.ShowDialog() == DialogResult.OK)
        {
            _text = updateDialog.UpdateText;
        }
        updateDialog.Dispose();
    }
    
    // ОБРАБОТЧИКИ НАЖАТИЙ
    // Удалить запись
    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
        DeleteTasks();
    }
    // Изменить запись
    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        ShowUpdateDialog();
        UpdateTasks();
    }
    // Открыть контекстное меню
    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                listBox1.SelectedIndex = index; // выделяем элемент
                _selectedMenuItem = listBox1.Items[index].ToString();
                _contextMenuStrip1.Show(listBox1, e.Location); // показываем меню в точке клика
            }
            else
            {
                _contextMenuStrip1.Hide(); // скрываем меню, если клик вне элемента
            }
        }
    }
    // Добавить задачу
    private void button1_Click(object sender, EventArgs e)
    {
       AddTasks();
       GetTasks();
    }
    
    // РАБОТА С БД
    // Получить значения из БД
    private void GetTasks()
    {
        string sqlExpression = "SELECT * FROM Tasks";
        using (var connection =
               new SqliteConnection($"Data Source={_path}"))
        {
            connection.Open();
            SqliteCommand commandReader = new SqliteCommand(sqlExpression, connection);
            listBox1.Items.Clear();
            using (SqliteDataReader reader = commandReader.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetValue(0);
                        var taskDesc = reader.GetValue(1);
                        listBox1.Items.Add($"{id}. {taskDesc}");
                    }
                }
            }    
        }
    }
    // Изменение задачи в БД
    private void UpdateTasks()
    {
        if (listBox1.SelectedItem != null)
        {
            string selectedItem = listBox1.SelectedItem.ToString();
            int dotIndex = selectedItem.IndexOf('.');
            if (dotIndex > -1)
            {
                string idStr = selectedItem.Substring(0, dotIndex);
                if (int.TryParse(idStr, out int taskId))
                {
                    string sqlExpression = "UPDATE Tasks SET TaskDesc = @desc WHERE TaskID = @id";

                    using (var connection = new SqliteConnection($"Data Source={_path}"))
                    {
                        connection.Open();
                        using (var command = new SqliteCommand(sqlExpression, connection))
                        {
                            command.Parameters.AddWithValue("@desc", _text);
                            command.Parameters.AddWithValue("@id", taskId);
                            command.ExecuteNonQuery();
                        }
                    }

                    GetTasks(); // обновить список
                }
            }
        }
    }
    // Удаление задачи из БД
    private void DeleteTasks()
    {
        if (listBox1.SelectedIndex > -1)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString() ?? string.Empty;
                int dotIndex = selectedItem.IndexOf('.');
                if (dotIndex > -1)
                {
                    string idStr = selectedItem.Substring(0, dotIndex);
                    if (int.TryParse(idStr, out int taskId))
                    {
                        string sqlExpression = $"DELETE FROM Tasks WHERE TaskID = {taskId}";
                        using var connection = new SqliteConnection($"Data Source={_path}");
                        connection.Open();
                        using var command = new SqliteCommand(sqlExpression, connection);
                        command.ExecuteNonQuery();
                        GetTasks();
                    }
                }
            }
        }
    }
    // Добавление задачи в БД
    private void AddTasks()
    {
        string taskDescription = textBox1.Text;
        using (var connection =
            new SqliteConnection($"Data Source={_path}"))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO Tasks (TaskDesc) VALUES (@desc)";
            command.Parameters.AddWithValue("@desc", taskDescription);
            command.ExecuteNonQuery();
        };
    }
}