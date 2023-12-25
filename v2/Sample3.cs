using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Theater
{
    public partial class Sample3 : Form
    {
        private string connectionString = "Data Source=Theater.db;Version=3;";

        private DataGridView TableSample3;

        public Sample3()
        {
            InitializeComponent();
            TableSample3 = new DataGridView();
            LoadDataIntoTableSample();
        }

        private void LoadDataIntoTableSample()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectDataQuery = "SELECT namePlays FROM roles GROUP BY namePlays HAVING COUNT(DISTINCT actor) > 3;";
                using (SQLiteCommand selectDataCommand = new SQLiteCommand(selectDataQuery, connection))
                {
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectDataCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Assign the populated DataTable to the DataGridView
                        TableSample.DataSource = dataTable;
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
    }
}
