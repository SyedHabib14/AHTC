using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace AHTC_2
{
    public partial class Form3 : Form
    {
        public Form3()
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
        private void button1_Click(object sender, EventArgs e)
        {

            Sqlconn.Open();
            string insert = "SELECT BID FROM Buyers";
            SqlCommand cmd = new SqlCommand(insert, Sqlconn);
            // int a = cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            Sqlconn.Close();

            reader.Read();
            current.Text = reader["BID"].ToString();
            reader.Close();
        }

        public void disp_data()
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "SELECT * FROM Buyers";
            SqlCommand cmd = new SqlCommand(Command, cn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            cn.Close();
        }

        void getIncrement()
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "SELECT BID FROM Buyers";
            SqlDataAdapter sda = new SqlDataAdapter(Command, cn);
            
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count < 1)
            {
                current.Text = "1";
            }
            else
            {
                string Command1 = "SELECT MAX(BID) FROM Buyers";
                SqlCommand cmd = new SqlCommand(Command1, cn);
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();

                a = a + 1;
                current.Text = a.ToString();
            }
            cn.Close();
        }
       /* private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string query = "UPDATE Buyers SET Gender = (@Gender) WHERE BID = BID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@gender", genderbox.GetItemText(genderbox.SelectedItem));
            cmd.ExecuteNonQuery();

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record Successfully Inserted :)");
            }
            else
            {
                MessageBox.Show("Record Insertion Failed :(");
            }

            cn.Close();
        } */

        private void PID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string insert = "INSERT INTO Buyers (First_Name, Last_Name, Phone, Email, Gender) VALUES ( '" + FNtxt.Text + "', '" + LNtxt.Text + "','" + Phtxt.Text + "', '" + mailtxt.Text + "', @Gender)";
            SqlCommand cmd = new SqlCommand(insert, cn);
            cmd.Parameters.AddWithValue("@gender", genderbox.GetItemText(genderbox.SelectedItem));
            int a = cmd.ExecuteNonQuery();

            string title = "SUCCESS!";
            MessageBox.Show("All Data Entered Successfully :)", title);
            getIncrement();
            cn.Close();

            FNtxt.Text = "";
            LNtxt.Text = "";
            Phtxt.Text = "";
            mailtxt.Text = "";
            // genderbox.Text = "";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            FNtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            LNtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Phtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            mailtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            genderbox.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            DELbtn.Enabled = true;
            UPbtn.Enabled = true;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "UPDATE Buyers SET First_Name = '" + FNtxt.Text + "', Last_Name = '" + LNtxt.Text + "', Phone = '" + Phtxt.Text + "', Email = '" + mailtxt.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, cn);
            // cmd.Parameters.AddWithValue("@gender", genderbox.GetItemText(genderbox.SelectedItem));
            int a = cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data Updated Successfully ^_^");
            cn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "DELETE FROM Buyers WHERE BID = BID";
            SqlCommand cmd = new SqlCommand(Command, cn);
            cmd.ExecuteNonQuery();
            cn.Close();

            MessageBox.Show("Selected Data Deleted Successfully ^_^");
            disp_data();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            UNL.Text = AHTC_SignIN.recby;
            disp_data();

            timer2.Start();

            getIncrement();
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            this.Close();
            new Calender().Show();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
            new dashboard().Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
        }

        private void inf_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("F"));
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

        private void UNL_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void SalesNav_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
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

        private void Displaybtn_Click(object sender, EventArgs e)
        {
            disp_data();   
        }

        private void DELbtn_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "DELETE FROM Buyers WHERE BID = BID";
            SqlCommand cmd = new SqlCommand(Command, cn);
            cmd.ExecuteNonQuery();
            cn.Close();

            string title = "SUCCESS!";
            MessageBox.Show("Selected Data Deleted Successfully ^_^", title);
            disp_data();
        }

        private void UPbtn_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "UPDATE Buyers SET First_Name = '" + FNtxt.Text + "', Last_Name = '" + LNtxt.Text + "', Phone = '" + Phtxt.Text + "', Email = '" + mailtxt.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, cn);
            // cmd.Parameters.AddWithValue("@gender", genderbox.GetItemText(genderbox.SelectedItem));
            int a = cmd.ExecuteNonQuery();
            string title = "SUCCESS!";
            MessageBox.Show("Selected Data Updated Successfully ^_^", title);
            cn.Close();
        }

        private void FN_Click(object sender, EventArgs e)
        {

        }

        private void mailtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void current_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
