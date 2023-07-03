using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHTC_2
{
    public partial class Calender : Form
    {
        public Calender()
        {
            InitializeComponent();
        }

        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new dashboard().Show();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txt1.Text = monthCalendar1.SelectionStart.ToString();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
            new dashboard().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (true)
            {
                this.BackColor = Color.FromArgb(105, 105, 105);
            }
            else
                this.BackColor = Color.Snow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form3().Show();
        }

        private void SalesNav_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form2().Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string message = "Do you want to exit the application?";
            string title = "AHTC - Signing off....";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
