using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace AHTC_2
{
    public partial class AHTC_SignIN : Form
    {
        
        public AHTC_SignIN()
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

        public static string username;

        public static string recby
        {
            get { return username;  }
            set { username = value; }
        }

        SqlConnection Sqlconn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter SqlDR = new SqlDataAdapter();
        
       

        private void button2_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            Password.Text = "";
            UserName.Focus();
        }

        private void peek_CheckedChanged(object sender, EventArgs e)
        {
            if (peek.Checked == true)
            {
                Password.PasswordChar = '\0';
            }
            else
            {
                Password.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        /* private void myButton1_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string login = "SELECT * FROM Accounts WHERE UserName = '" + UserName.Text + "' and Password = '" + Password.Text + "'";
            cmd = new SqlCommand(login, Sqlconn);
            SqlDataReader sdr = cmd.ExecuteReader();


            if (sdr.Read() == true)
            {
                recby = UserName.Text;
                new dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserName.Text = "";
                Password.Text = "";
                UserName.Focus();
            }
        } */

        private void button1_Click_1(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string login = "SELECT * FROM Accounts WHERE UserName = '" + UserName.Text + "' and Password = '" + Password.Text + "'";
            cmd = new SqlCommand(login, Sqlconn);
            SqlDataReader sdr = cmd.ExecuteReader();


            if (sdr.Read() == true)
            {
                recby = UserName.Text;
                new dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserName.Text = "";
                Password.Text = "";
                UserName.Focus();
            } 
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
