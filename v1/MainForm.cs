using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Theater
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Plays playsForm = new Plays();
            playsForm.Show();
            this.Hide();

        }

        private void ActorButton_Click(object sender, EventArgs e)
        {
            Actor actorForm = new Actor();
            actorForm.Show();
            this.Hide();

        }

        private void TheaterButton_Click(object sender, EventArgs e)
        {
            string theatersMessage = "1)Государственный русский драматический театр Удмуртии\n" +
                                     "2)Государственный театр оперы и балета Удмуртской Республики имени П.И. Чайковского\n" +
                                     "3)Государственный национальный театр Удмуртской Республики\n" +
                                     "4)Государственный театр кукол Удмуртской Республики\n" +
                                     "5)Удмуртский государственный театр фольклорной песни и танца «Айкай»\n" +
                                     "6)Муниципальный молодежный театр «Молодой человек»\n" +
                                     "7)Театр «Птица», Театр юного зрителя г. Ижевска";

            // Создание кастомного диалогового окна
            Form customMessageBox = new Form();
            Label label = new Label();
            Button button = new Button();

            customMessageBox.Text = "Название театров";
            label.Text = theatersMessage;
            button.Text = "OK";
            button.Click += (btnSender, btnArgs) =>
            {
                customMessageBox.Close();
            };

            customMessageBox.Controls.Add(label);
            customMessageBox.Controls.Add(button);
            customMessageBox.BackColor = Color.NavajoWhite;
            label.Dock = DockStyle.Fill;
            button.Dock = DockStyle.Bottom;

            customMessageBox.ShowDialog();
        }        


        private void ProductionsButton_Click(object sender, EventArgs e)
        {
            Productions productionsForm = new Productions();
            productionsForm.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Schedule scheduleForm = new Schedule();
            scheduleForm.Show();
            this.Hide();
        }
    }
    }
