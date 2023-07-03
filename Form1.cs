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
    public partial class Form1 : Form
    {
        public Form1()
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

        SqlConnection Sqlconn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter SqlDR = new SqlDataAdapter();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text == "" && FirstPass.Text == "" && ConfPass.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Sign UP Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (FirstPass.Text == ConfPass.Text)
            {
                Sqlconn.Open();
                string register = "INSERT INTO Accounts VALUES ('" + UserName.Text + "','" + FirstPass.Text + "')";
                cmd = new SqlCommand(register, Sqlconn);
                cmd.ExecuteNonQuery();
                Sqlconn.Close();

                UserName.Text = "";
                FirstPass.Text = "";
                ConfPass.Text = "";

                MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FirstPass.Text = "";
                ConfPass.Text = "";
                FirstPass.Focus();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new AHTC_SignIN().Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            FirstPass.Text = "";
            ConfPass.Text = "";
            UserName.Focus();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ChechbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked == true)
            {
                FirstPass.PasswordChar = '\0';
                ConfPass.PasswordChar = '\0';
            }
            else
            {
                FirstPass.PasswordChar = '•';
                ConfPass.PasswordChar = '•';
            }
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
    }
}