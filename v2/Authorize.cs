using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Theater
{
    public partial class Authorize : Form
    {
        private readonly string connectionString = "Data Source=Theater.db;Version=3;";
        public Authorize()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM auth WHERE login=@login AND password=@password";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@login", LoginField.Text);
                    command.Parameters.AddWithValue("@password", passField.Text);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Авторизация прошла успешно");
                            // код для входа обычного пользователя
                            Form fAuthorization = new MainForm();
                            fAuthorization.Show();
                            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль были неверны.");
                        }
                    }
                }
            }
        }
        private void form_FormClosed(object sender, EventArgs e)
        {  
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
