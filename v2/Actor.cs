using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Theater
{
    public partial class Actor : Form
    {
        private string connectionString = "Data Source=Theater.db;Version=3;";
        public Actor()
        {
            InitializeComponent();
            LoadDataIntoTableActor();
        }

        private void LoadDataIntoTableActor()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS worker (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,name TEXT,range TEXT,idRole TEXT,gender TEXT)";
                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                string selectDataQuery = "SELECT * FROM worker";
                using (SQLiteCommand selectDataCommand = new SQLiteCommand(selectDataQuery, connection))
                {
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectDataCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        TableActor.DataSource = dataTable;

                        TableActor.Columns["id"].Visible = false;
                        TableActor.Columns["idRole"].Visible = false;

                    }
                }

                connection.Close();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = "INSERT INTO worker (name, range, gender) VALUES (@name,@gender,@range)";
                using (SQLiteCommand insertDataCommand = new SQLiteCommand(insertDataQuery, connection))
                {
                    insertDataCommand.Parameters.AddWithValue("@name", Name1.Text);
                    insertDataCommand.Parameters.AddWithValue("@range", RangeTextBox.Text);
                    insertDataCommand.Parameters.AddWithValue("@gender", GenderTextBox.Text);



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
                                
                                Thread.Sleep(1000); 
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
                        LoadDataIntoTableActor();

                        Name1.Text = "";
                        RangeTextBox.Text = "";

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

        private void MainButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TableActor.SelectedRows.Count > 0)
            {
                int selectedRowIndex = TableActor.SelectedRows[0].Index;
                int roleId = Convert.ToInt32(TableActor.Rows[selectedRowIndex].Cells["id"].Value);

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string deleteDataQuery = "DELETE FROM worker WHERE id = @id";
                    using (SQLiteCommand deleteDataCommand = new SQLiteCommand(deleteDataQuery, connection))
                    {
                        deleteDataCommand.Parameters.AddWithValue("@id", roleId);

                        try
                        {
                            deleteDataCommand.ExecuteNonQuery();

                            LoadDataIntoTableActor();

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
