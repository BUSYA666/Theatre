using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Theater
{
    public partial class Sample1 : Form
    {
        private string connectionString = "Data Source=Theater.db;Version=3;";
        private DataGridView TableSample; // Добавьте элемент DataGridView на вашу форму и укажите соответствующее имя

        public Sample1()
        {
            InitializeComponent();
            LoadDataIntoTableSample1();
        }

        private void LoadDataIntoTableSample1()
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

                        // Создание DataView для таблицы данных
                        DataView dataView = new DataView(dataTable);

                        // Применение фильтра по столбцу "director" со значением "Балаян"
                        dataView.RowFilter = "director = 'Балаян'";

                        // Установка источника данных для TableSample
                        TableSample.DataSource = dataView;

                        // Скрытие ненужных столбцов
                        TableSample.Columns["id"].Visible = false;
                        TableSample.Columns["idWorker"].Visible = false;
                        TableSample.Columns["NameRoles"].Visible = false;
                        TableSample.Columns["dateStart"].Visible = false;
                        TableSample.Columns["dataEnd"].Visible = false;
                    }
                }

                connection.Close();
            }
        }

        private void MainButton_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}