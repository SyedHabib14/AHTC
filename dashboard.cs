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
using Bunifu.UI.WinForms.BunifuButton;
using AHTC_2.Properties;


namespace AHTC_2
{
    public partial class dashboard : Form
    {
        private bool isCollapsed;
        public dashboard()
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
        private void BtnDashboard_Click(object sender, EventArgs e)
        {

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            UNL.Text = AHTC_SignIN.recby; 
            disp_data();

            timer2.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button1.Image = Resources.Collapse_Arrow_20px;
                
                panelDD.Height -= 10;
                if (panelDD.Size == panelDD.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            
            else
            {

                button1.Image = Resources.Expand_Arrow_20px;
                panelDD.Height += 10;
                if (panelDD.Size == panelDD.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;

                }
            }

        }

        public void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string insert = "INSERT INTO Products (PID, ProductName, Price, Details) VALUES ( '" + PID.Text + "', '" + ProductName.Text + "','" + Price.Text + "', '" + Details.Text + "')";
            SqlCommand cmd = new SqlCommand(insert, Sqlconn);
            int a = cmd.ExecuteNonQuery();
            Sqlconn.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string Command = "UPDATE Products SET CategoryID = '1' WHERE PID = '" + PID.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

            string title = "Shabash Beta Bahut Bariya Munna :)";
            MessageBox.Show("All Data Entered Successfully ^_^", title);
            // disp_data();
        }

        public void disp_data ()
        {
            Sqlconn.Open();
            string Command = "SELECT PID, ProductName, Price, Details, Quantity FROM Products";
            SqlCommand cmd = new SqlCommand(Command, Sqlconn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            Sqlconn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string Command = "DELETE FROM Products WHERE PID = '" + PID.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

            MessageBox.Show("Selected Data Deleted Successfully ^_^");
            disp_data();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string Command = "UPDATE Products SET PID = '" + PID.Text + "', ProductName = '" + ProductName.Text + "', Price = '" + Price.Text + "', Details = '" + Details.Text + "' WHERE PID = '" + PID.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, Sqlconn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data Updated Successfully ^_^");
            Sqlconn.Close();

            
            // disp_data();
        }

        private void UNL_Click(object sender, EventArgs e)
        {
            
        }

        private void inf_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("F"));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
        }

        private void Header_Click(object sender, EventArgs e)
        {

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

        private void btnCalender_Click(object sender, EventArgs e)
        {
            this.Close();
            new Calender().Show();
        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string Command = "UPDATE Products SET CategoryID = '2' WHERE PID = '" + PID.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, Sqlconn);
            cmd.ExecuteNonQuery();

            Sqlconn.Close();

            string title = "Shabash Beta Bahut Bariya Munna :)";
            MessageBox.Show("All Data Entered Successfully ^_^", title);
            // disp_data();
        }

        private void BtnDashboard_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            ProductName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Price.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Details.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            DELbtn.Enabled = true;
            UPbtn.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Sales_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form3().Show();
        }

        private void Time_Click(object sender, EventArgs e)
        {

        }

        private void SalesNav_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form2().Show();
        }

        private void donebtn_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string insert = "INSERT INTO Products (PID, ProductName, Price, Details, Quantity) VALUES ( '" + PID.Text + "', '" + ProductName.Text + "','" + Price.Text + "', '" + Details.Text + "', '" + Quantity.Text + "')";
            SqlCommand cmd = new SqlCommand(insert, Sqlconn);
            int a = cmd.ExecuteNonQuery();
            Sqlconn.Close();

            string title = "SUCCESS!";
            MessageBox.Show("All data inserted succesfully ^_^ \nPlease choose a category below.", title);
        }

        private void Displaybtn_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void DELbtn_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string Command = "DELETE FROM Products WHERE PID = '" + PID.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

            MessageBox.Show("Selected Data Deleted Successfully ^_^");
            disp_data();
        }

        private void UPbtn_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string Command = "UPDATE Products SET PID = '" + PID.Text + "', ProductName = '" + ProductName.Text + "', Price = '" + Price.Text + "', Details = '" + Details.Text + "' WHERE PID = '" + PID.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, Sqlconn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data Updated Successfully ^_^");
            Sqlconn.Close();

        }

        private void Quantity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
