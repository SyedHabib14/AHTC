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

namespace AHTC_2
{
    public partial class Form2 : Form
    {
        public Form2()
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

        private bool bt6Check = false;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UNL.Text = AHTC_SignIN.recby;
            disp_data();

            timer2.Start();
        }

        private void inf_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("F"));
        }
        private void label5(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string insert = "Insert Into ShoppingCart (OrderNo, DATE_TIME, Product_ID, CustomerID, Quantity) VALUES ((ABS(checksum(NewId()) % 10000)), GETDATE(), '" + ProductID.Text + "', '" + CustomerID.Text + "', '" + Quantity.Text + "');";
            SqlCommand cmd = new SqlCommand(insert, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
            bt6Check = true;

            if (bt6Check == true)
            {
                Sqlconn.Open();
                string query = "UPDATE ShoppingCart SET IsInCart = 'Added' WHERE OrderID = OrderID";
                SqlCommand new_cmd = new SqlCommand(query, Sqlconn);
                int a = new_cmd.ExecuteNonQuery();
                Sqlconn.Close();
                status.Text = "PRODUCT ADDED";
                bt6Check = false;
            }

            else
            {
                Sqlconn.Open();
                string query = "UPDATE ShoppingCart SET IsInCart = 'Not Added' WHERE OrderID = OrderID";
                SqlCommand new_cmd = new SqlCommand(query, Sqlconn);
                int a = new_cmd.ExecuteNonQuery();
                Sqlconn.Close();
                status.Text = "NO PRODUCT ADDED";
            }
        }

        private void PID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sales_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Calender().Show();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dashboard().Show();
        }

        private void SalesNav_Click(object sender, EventArgs e)
        {
            
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
        }

        internal class Show
        {
            public Show()
            {
            }
        }

        public void disp_data()
        {
            Sqlconn.Open();
            string Command = "  SELECT CustomerID, First_Name, Last_Name, OrderNo, Product_ID, Quantity, IsInCart, DATE_TIME FROM ShoppingCart JOIN Buyers ON Buyers.BID = ShoppingCart.CustomerID";
            SqlCommand cmd = new SqlCommand(Command, Sqlconn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;

            Sqlconn.Close();
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

        
        
        private void Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Chip1_Click(object sender, EventArgs e)
        {

        }

        private void status_Click(object sender, EventArgs e)
        {

        }

        private void checkout_Click(object sender, EventArgs e)
        {
            Sqlconn.Open();
            string insert = "Insert Into ShoppingCart (OrderNo, DATE_TIME, Product_ID, CustomerID, Quantity) VALUES ((ABS(checksum(NewId()) % 10000)), GETDATE(), '" + ProductID.Text + "', '" + CustomerID.Text + "', '" + Quantity.Text + "');";
            SqlCommand cmd = new SqlCommand(insert, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
            bt6Check = true;

            Sqlconn.Open();
            string decreament = "UPDATE Products SET Quantity = Quantity - '" + Quantity.Text + "' WHERE PID = '" + ProductID.Text + "'";
            SqlCommand dec_cmd = new SqlCommand(decreament, Sqlconn);
            dec_cmd.ExecuteNonQuery();
            Sqlconn.Close();


            if (bt6Check == true)
            {
                Sqlconn.Open();
                string query = "UPDATE ShoppingCart SET IsInCart = 'Added' WHERE OrderID = OrderID";
                SqlCommand new_cmd = new SqlCommand(query, Sqlconn);
                int a = new_cmd.ExecuteNonQuery();
                Sqlconn.Close();
                status.Text = " PRODUCT ADDED ";
                string title = "SUCCESS!";
                MessageBox.Show("Successfully Added to the Cart :)", title);

                Sqlconn.Open();
                string Total = "SELECT SUM(Price * ShoppingCart.Quantity) FROM Products JOIN ShoppingCart ON ShoppingCart.Product_ID = Products.PID JOIN Buyers ON Buyers.BID = ShoppingCart.CustomerID WHERE ShoppingCart.Product_ID = '" + ProductID.Text + "' AND ShoppingCart.CustomerID = '" + CustomerID.Text + "' AND CAST(ShoppingCart.DATE_TIME AS DATE) = CAST(GETDATE() AS DATE)";
                SqlCommand com = new SqlCommand(Total, Sqlconn);
                SqlDataReader DR = com.ExecuteReader();

                while (DR.Read())
                {
                    TotalPrice.Text = DR.GetValue(0).ToString();
                }
                                 
                DR.Close();
                Sqlconn.Close();
                bt6Check = false;               
            }

            else if (bt6Check == false)
            {
                Sqlconn.Open();
                string query = "UPDATE ShoppingCart SET IsInCart = 'Not Added' WHERE OrderID = OrderID";
                SqlCommand new_cmd = new SqlCommand(query, Sqlconn);
                int a = new_cmd.ExecuteNonQuery();
                Sqlconn.Close();
                status.Text = " NO PRODUCT ADDED ";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void Displaybtn_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void UPbtn_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "UPDATE ShoppingCart SET CustomerID = '" + CustomerID.Text + "', Product_ID = '" + ProductID.Text + "', Quantity = '" + Quantity.Text + "' ";
            SqlCommand cmd = new SqlCommand(Command, cn);
            // cmd.Parameters.AddWithValue("@gender", genderbox.GetItemText(genderbox.SelectedItem));
            int a = cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data Updated Successfully ^_^");
            cn.Close();
        }

        private void DELbtn_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "DELETE FROM ShoppingCart WHERE CustomerID = '" + delCust.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, cn);
            cmd.ExecuteNonQuery();
            cn.Close();

            string title = "SUCCESS!";
            MessageBox.Show("Selected Data Deleted Successfully ^_^", title);
            disp_data();
        }

        private void DELbtnOrder_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=XEON\\SQLEXPRESS; Initial Catalog=AHTC;Integrated Security=True");
            cn.Open();

            string Command = "DELETE FROM ShoppingCart WHERE OrderNo = '" + delOrder.Text + "'";
            SqlCommand cmd = new SqlCommand(Command, cn);
            cmd.ExecuteNonQuery();
            cn.Close();

            string title = "SUCCESS!";
            MessageBox.Show("Selected Data Deleted Successfully ^_^", title);
            disp_data();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerID.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            ProductID.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Quantity.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


            DELbtnCust.Enabled = true;
            DELbtnOrder.Enabled = true;
            UPbtn.Enabled = true;
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

        }

        private void Header_Click(object sender, EventArgs e)
        {

        }

        private void MoneyRec_ValueChanged(object sender, EventArgs e)
        {

        }

        bool checkClick = false;
        private void Confirm_Click(object sender, EventArgs e)
        {
            
            checkClick = true;
            /* SqlDataReader dr = diff_cmd.ExecuteReader();

            while (dr.Read())
            {
                BackPay.Text = dr.GetValue(0).ToString();
            }

            dr.Close(); */

            
        }

        private void BackPay_Click(object sender, EventArgs e)
        {

        }

        private void Result_TextChanged(object sender, EventArgs e)
        {
            if (checkClick)
            {
                Sqlconn.Open();
                string Diff = "SELECT TRY_CAST('" + MoneyRec + "' AS INT) - (SELECT SUM(Price * ShoppingCart.Quantity) FROM Products JOIN ShoppingCart ON ShoppingCart.Product_ID = Products.PID JOIN Buyers ON Buyers.BID = ShoppingCart.CustomerID WHERE ShoppingCart.Product_ID = '" + ProductID.Text + "' AND ShoppingCart.CustomerID = '" + CustomerID.Text + "' AND CAST(ShoppingCart.DATE_TIME AS DATE) = CAST(GETDATE() AS DATE))";
                SqlCommand diff_cmd = new SqlCommand(Diff, Sqlconn);
                string temp = diff_cmd.ExecuteScalar().ToString();

                Result.Text = temp;
                Sqlconn.Close();
            }
        }
    }
}
