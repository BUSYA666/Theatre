using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Theater
{
    public partial class Reg : Form
    {
        private readonly string connectionString = "Data Source=Theater.db;Version=3;";

        public Reg()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = LoginField.Text;
            string password = passField.Text;

            // Проверка, если поля логина и пароля пусты
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            // Проверка, если такой пользователь уже существует
            string checkUserSql = "SELECT COUNT(*) FROM auth WHERE login=@login";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand checkUserCommand = new SQLiteCommand(checkUserSql, connection))
                {
                    checkUserCommand.Parameters.AddWithValue("@login", login);
                    int userCount = Convert.ToInt32(checkUserCommand.ExecuteScalar());
                    if (userCount > 0)
                    {
                        MessageBox.Show("Такой пользователь уже существует.");
                        return;
                    }
                }
            }

            // Регистрация нового пользователя
            string insertUserSql = "INSERT INTO auth (login, password) VALUES (@login, @password)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand insertUserCommand = new SQLiteCommand(insertUserSql, connection))
                {
                    insertUserCommand.Parameters.AddWithValue("@login", login);
                    insertUserCommand.Parameters.AddWithValue("@password", password);
                    int rowsAffected = insertUserCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Регистрация прошла успешно.");

                        // Добавление нового пользователя
                        string name = NameField.Text;
                        string range = RangeField.Text;
                        string idRole = IdRoleField.Text;
                        string gender = GenderField.Text;

                        string insertUserDetailsSql = "INSERT INTO worker (name, range, idRole, gender) VALUES (@Name, @Range, @IdRole, @Gender)";
                        using (SQLiteCommand insertUserDetailsCommand = new SQLiteCommand(insertUserDetailsSql, connection))
                        {
                            insertUserDetailsCommand.Parameters.AddWithValue("@Name", name);
                            insertUserDetailsCommand.Parameters.AddWithValue("@Range", range);
                            insertUserDetailsCommand.Parameters.AddWithValue("@IdRole", idRole);
                            insertUserDetailsCommand.Parameters.AddWithValue("@Gender", gender);

                            try
                            {
                                rowsAffected = insertUserDetailsCommand.ExecuteNonQuery();
                                MessageBox.Show("Новый пользователь успешно добавлен.");
                                // Код для входа обычного пользователя
                                Form fAuthorization = new MainForm();
                                fAuthorization.Show();
                                fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
                                this.Hide();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при добавлении нового пользователя: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при регистрации пользователя.");
                    }
                }
            }
        }

        private void form_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}