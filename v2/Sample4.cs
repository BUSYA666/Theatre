using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Theater
{
    public partial class Sample4 : Form
    {
        private string connectionString = "Data Source=Theater.db;Version=3;";
        private DataGridView TableSample4; 

        public Sample4()
        {
            InitializeComponent();
            LoadDataIntoTableSample();
        }

        private void LoadDataIntoTableSample()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectDataQuery = "SELECT id, actor, data FROM prostoi";
                using (SQLiteCommand selectDataCommand = new SQLiteCommand(selectDataQuery, connection))
                {
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectDataCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Create a DataView for the data table
                        DataView dataView = new DataView(dataTable);

                        // Set the data source for TableSample
                        TableSample.DataSource = dataView;

                        TableSample.Columns["id"].Visible = false;


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

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}