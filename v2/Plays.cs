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
    public partial class Plays : Form
    {
        public Plays()
        {
            InitializeComponent();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    private void button1_Click(object sender, EventArgs e)
        {
            Sample1 sample1 = new Sample1();
            sample1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sample2 sample2 = new Sample2();
            sample2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sample3 sample3 = new Sample3();
            sample3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sample4 sample4 = new Sample4();
            sample4.Show();
            this.Hide();
        }
    }
}
