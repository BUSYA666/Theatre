using System;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;

namespace Theater
{
    public partial class Productions : Form
    {
        private string connectionString = "Data Source=Theater.db;Version=3;";

        public Productions()
        {
            InitializeComponent();
            LoadDataIntoTableProduction();
        }

        private void LoadDataIntoTableProduction()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = "CREATE TABLE IF NOT EXISTS roles (id INTEGER NOT NULL UNIQUE, nameRoles TEXT, actor TEXT, namePlays TEXT, PRIMARY KEY(id AUTOINCREMENT));";
                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                string selectDataQuery = "SELECT * FROM roles";
                using (SQLiteCommand selectDataCommand = new SQLiteCommand(selectDataQuery, connection))
                {
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectDataCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        TableProduction.DataSource = dataTable;

                        TableProduction.Columns["id"].Visible = false;
                    }
                }

                connection.Close();
            }
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

                string insertDataQuery = "INSERT INTO roles (namePlays, data) VALUES (@namePlays, @data)";
                using (SQLiteCommand insertDataCommand = new SQLiteCommand(insertDataQuery, connection))
                {
                    insertDataCommand.Parameters.AddWithValue("@namePlays", Name1.Text);
                    insertDataCommand.Parameters.AddWithValue("@data", DateTextBox.Text);

                    const int maxRetries = 5;
                    int retries = 0;
                    bool success = false;

                    while (retries < maxRetries)
                    {
                        try
                        {
                            insertDataCommand.ExecuteNonQuery();
                            success = true;
                            break;
                        }
                        catch (SQLiteException ex)
                        {
                            if (ex.ErrorCode == (int)SQLiteErrorCode.Locked)
                            {
                                // Database is locked, wait for a certain amount of time before retrying
                                Thread.Sleep(1000); // Wait for 1 second before retrying
                            }
                            else
                            {
                                MessageBox.Show("Произошла ошибка при сохранении данных: " + ex.Message);
                                success = false;
                                break;
                            }
                        }

                        retries++;
                    }

                    if (success)
                    {
                        LoadDataIntoTableProduction();

                        Name1.Text = "";
                        DateTextBox.Text = "";

                        MessageBox.Show("Данные сохранены!");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось сохранить данные. Попробуйте еще раз позже.");
                    }
                }

                connection.Close();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TableProduction.SelectedRows.Count > 0)
            {
                int selectedRowIndex = TableProduction.SelectedRows[0].Index;
                int roleId = Convert.ToInt32(TableProduction.Rows[selectedRowIndex].Cells["id"].Value);

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string deleteDataQuery = "DELETE FROM roles WHERE id = @id";
                    using (SQLiteCommand deleteDataCommand = new SQLiteCommand(deleteDataQuery, connection))
                    {
                        deleteDataCommand.Parameters.AddWithValue("@id", roleId);

                        try
                        {
                            deleteDataCommand.ExecuteNonQuery();

                            LoadDataIntoTableProduction();

                            MessageBox.Show("Строка удалена!");
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show("Произошла ошибка при удалении строки: " + ex.Message);
                        }
                    }

                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}