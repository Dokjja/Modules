using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TaskManagerWPF
{
    public partial class MainWindow : Window
    {
        string dbPath = "tasks.db";

        public MainWindow()
        {
            InitializeComponent();
            InitDatabase();
            LoadTasks();
            StartDeadlineCheck();
        }

        SQLiteConnection GetConnection()
        {
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            conn.Open();
            return conn;
        }

        void InitDatabase()
        {
            using var conn = GetConnection();
            var cmd = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS Tasks (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Priority TEXT,
                    DueDate TEXT,
                    IsDone INTEGER DEFAULT 0
                );", conn);
            cmd.ExecuteNonQuery();
        }

        void LoadTasks()
        {
            TaskListBox.Items.Clear();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("SELECT * FROM Tasks", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string line = $"{reader["Name"]} | {reader["Priority"]} | {reader["DueDate"]} | {(Convert.ToInt32(reader["IsDone"]) == 1 ? "✔" : "⏳")}";
                TaskListBox.Items.Add(line);
            }
        }

        void AddTask_Click(object sender, RoutedEventArgs e)
        {
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("INSERT INTO Tasks (Name, Priority, DueDate, IsDone) VALUES (@n, @p, @d, @done)", conn);
            cmd.Parameters.AddWithValue("@n", TaskNameTextBox.Text);
            cmd.Parameters.AddWithValue("@p", ((ComboBoxItem)PriorityComboBox.SelectedItem)?.Content.ToString());
            cmd.Parameters.AddWithValue("@d", DueDatePicker.SelectedDate?.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@done", IsDoneCheckBox.IsChecked == true ? 1 : 0);
            cmd.ExecuteNonQuery();
            LoadTasks();
        }

        void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem == null) return;
            string name = TaskListBox.SelectedItem.ToString().Split('|')[0].Trim();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("DELETE FROM Tasks WHERE Name = @n", conn);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.ExecuteNonQuery();
            LoadTasks();
        }

        void EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem == null) return;
            string name = TaskListBox.SelectedItem.ToString().Split('|')[0].Trim();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("UPDATE Tasks SET Priority = @p, DueDate = @d, IsDone = @done WHERE Name = @n", conn);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@p", ((ComboBoxItem)PriorityComboBox.SelectedItem)?.Content.ToString());
            cmd.Parameters.AddWithValue("@d", DueDatePicker.SelectedDate?.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@done", IsDoneCheckBox.IsChecked == true ? 1 : 0);
            cmd.ExecuteNonQuery();
            LoadTasks();
        }

        void StartDeadlineCheck()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
            timer.Tick += (s, e) =>
            {
                using var conn = GetConnection();
                var cmd = new SQLiteCommand("SELECT Name, DueDate FROM Tasks WHERE IsDone = 0", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime due = DateTime.Parse(reader["DueDate"].ToString());
                    if ((due - DateTime.Now).TotalHours <= 24)
                    {
                        MessageBox.Show($"Задача '{reader["Name"]}' истекает в течение суток!", "Напоминание");
                    }
                }
            };
            timer.Start();
        }
    }
}
