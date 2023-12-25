using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Theater
{
    public partial class Schedule : Form
    {
        private string connectionString = "Data Source=Theater.db;Version=3;";

        public Schedule()
        {
            InitializeComponent();
            LoadDataIntoTableSchedule();
        }

        private void LoadDataIntoTableSchedule()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectDataQuery = "SELECT id, idWorker, Actor, dateStart, dataEnd, director, NameRoles FROM schedule";
                using (SQLiteCommand selectDataCommand = new SQLiteCommand(selectDataQuery, connection))
                {
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectDataCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Установка источника данных для TableSchedule
                        TableSchedule.DataSource = dataTable;

                        // Скрытие ненужных столбцов
                        TableSchedule.Columns["id"].Visible = false;
                        TableSchedule.Columns["idWorker"].Visible = false;
                    }
                }

                connection.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = "INSERT INTO schedule (director, dateStart, dataEnd, actor, NameRoles) VALUES (@director, @dateStart, @dataEnd, @actor, @NameRoles)";
                using (SQLiteCommand insertDataCommand = new SQLiteCommand(insertDataQuery, connection))
                {
                    insertDataCommand.Parameters.AddWithValue("@director", Name1.Text);
                    insertDataCommand.Parameters.AddWithValue("@dateStart", DateTextBox.Text);
                    insertDataCommand.Parameters.AddWithValue("@dataEnd", TimeTextBox.Text);
                    insertDataCommand.Parameters.AddWithValue("@actor", ActorTextBox.Text);
                    insertDataCommand.Parameters.AddWithValue("@NameRoles", RolesTextBox.Text);

                    insertDataCommand.ExecuteNonQuery();

                    // Обновление данных в TableSchedule после сохранения
                    LoadDataIntoTableSchedule();

                    // Очистка текстовых полей после сохранения
                    Name1.Text = "";
                    DateTextBox.Text = "";
                    TimeTextBox.Text = "";
                    ActorTextBox.Text = "";
                    RolesTextBox.Text = "";

                    MessageBox.Show("Данные сохранены!");
                }

                connection.Close();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TableSchedule.SelectedRows.Count > 0)
            {
                int selectedRowIndex = TableSchedule.SelectedRows[0].Index;
                int scheduleId = Convert.ToInt32(TableSchedule.Rows[selectedRowIndex].Cells["id"].Value);

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string deleteDataQuery = "DELETE FROM schedule WHERE id = @id";
                    using (SQLiteCommand deleteDataCommand = new SQLiteCommand(deleteDataQuery, connection))
                    {
                        deleteDataCommand.Parameters.AddWithValue("@id", scheduleId);
                        deleteDataCommand.ExecuteNonQuery();

                        // Обновление данных в TableSchedule после удаления
                        LoadDataIntoTableSchedule();

                        MessageBox.Show("Строка удалена!");
                    }

                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!");
            }
        }
              
    }
}
