using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;

namespace Module_9._2
{
    public partial class MainWindow : Window
    {
        private string dbPath = "projects.db";

        public MainWindow()
        {
            InitializeComponent();
            InitDatabase();
            LoadProjects();
            LoadEmployees();
            LoadTasks();
        }

        private SQLiteConnection GetConnection()
        {
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            conn.Open();
            return conn;
        }

        private void InitDatabase()
        {
            using var conn = GetConnection();
            using var cmd = new SQLiteCommand(conn);
            cmd.CommandText = @"
    CREATE TABLE IF NOT EXISTS Projects (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Name TEXT NOT NULL,
        IsActive INTEGER DEFAULT 1
    );
    CREATE TABLE IF NOT EXISTS Employees (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Name TEXT NOT NULL
    );
    CREATE TABLE IF NOT EXISTS Tasks (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        Name TEXT NOT NULL,
        Priority TEXT,
        DueDate TEXT,
        EmployeeId INTEGER,
        ProjectId INTEGER,
        FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
        FOREIGN KEY(ProjectId) REFERENCES Projects(Id)
    );
";

            cmd.ExecuteNonQuery();
        }

        // Проекты
        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("INSERT INTO Projects (Name) VALUES (@name)", conn);
            cmd.Parameters.AddWithValue("@name", ProjectNameTextBox.Text);
            cmd.ExecuteNonQuery();
            LoadProjects();
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListBox.SelectedItem == null) return;
            string name = ProjectListBox.SelectedItem.ToString();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("DELETE FROM Projects WHERE Name = @name", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            LoadProjects();
        }

        private void LoadProjects()
        {
            ProjectListBox.Items.Clear();
            ProjectComboBox.Items.Clear(); // для задач

            using var conn = GetConnection();
            var cmd = new SQLiteCommand("SELECT Id, Name FROM Projects WHERE IsActive = 1", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                int id = Convert.ToInt32(reader["Id"]);
                ProjectListBox.Items.Add(name);
                ProjectComboBox.Items.Add(new ComboBoxItem { Content = name, Tag = id });
            }
        }
        // Сотрудники
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("INSERT INTO Employees (Name) VALUES (@name)", conn);
            cmd.Parameters.AddWithValue("@name", EmployeeNameTextBox.Text);
            cmd.ExecuteNonQuery();
            LoadEmployees();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListBox.SelectedItem == null) return;
            string name = EmployeeListBox.SelectedItem.ToString();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("DELETE FROM Employees WHERE Name = @name", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            EmployeeListBox.Items.Clear();
            EmployeeComboBox.Items.Clear();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("SELECT Name FROM Employees", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                EmployeeListBox.Items.Add(name);
                EmployeeComboBox.Items.Add(name);
            }
        }

        // Задачи
        private void AssignTask_Click(object sender, RoutedEventArgs e)
        {
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("INSERT INTO Tasks (Name, Priority, DueDate, EmployeeId, ProjectId) VALUES (@name, @priority, @due, @emp, @proj)", conn);
            cmd.Parameters.AddWithValue("@name", TaskNameTextBox.Text);
            cmd.Parameters.AddWithValue("@priority", ((ComboBoxItem)PriorityComboBox.SelectedItem)?.Content.ToString());
            cmd.Parameters.AddWithValue("@due", DueDatePicker.SelectedDate?.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@emp", GetEmployeeId(EmployeeComboBox.SelectedItem?.ToString()));
            cmd.Parameters.AddWithValue("@proj", GetProjectId(ProjectComboBox.SelectedItem));
            cmd.ExecuteNonQuery();
            LoadTasks();
        }
        private int GetProjectId(object selectedItem)
        {
            if (selectedItem is ComboBoxItem item && item.Tag is int id)
                return id;
            return 0;
        }
        
        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem == null) return;
            string name = TaskListBox.SelectedItem.ToString().Split('|')[0].Trim();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("DELETE FROM Tasks WHERE Name = @name", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            LoadTasks();
        }

        private void LoadTasks()
        {
            TaskListBox.Items.Clear();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand(@"
        SELECT Tasks.Name, Priority, DueDate, Employees.Name AS EmpName, Projects.Name AS ProjectName
        FROM Tasks
        LEFT JOIN Employees ON Tasks.EmployeeId = Employees.Id
        LEFT JOIN Projects ON Tasks.ProjectId = Projects.Id", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string task = $"{reader["Name"]} | {reader["Priority"]} | {reader["DueDate"]} | {reader["EmpName"]} | {reader["ProjectName"]}";
                TaskListBox.Items.Add(task);
            }
        }


        private int GetEmployeeId(string name)
        {
            using var conn = GetConnection();
            var cmd = new SQLiteCommand("SELECT Id FROM Employees WHERE Name = @name", conn);
            cmd.Parameters.AddWithValue("@name", name);
            var result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }

        // Отчёты
        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            ReportTextBox.Clear();
            using var conn = GetConnection();
            var cmd = new SQLiteCommand(@"
                SELECT Tasks.Name AS TaskName, Priority, DueDate, Employees.Name AS EmployeeName
                FROM Tasks
                LEFT JOIN Employees ON Tasks.EmployeeId = Employees.Id", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReportTextBox.AppendText(
                    $"Задача: {reader["TaskName"]}\n" +
                    $"Приоритет: {reader["Priority"]}\n" +
                    $"Срок: {reader["DueDate"]}\n" +
                    $"Сотрудник: {reader["EmployeeName"]}\n\n"
                );
            }
        }
    }
}
