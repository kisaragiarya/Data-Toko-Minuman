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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-EJH2D6F\\ARYA;Initial Catalog=finalPABD;User ID=sa;Password=arya@cool123;");
            string query = "SELECT * FROM login WHERE UserId = '" + textBoxUser.Text.Trim() + "' and Pword = '" + textBoxPassword.Text.Trim() + "'" ;
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Login Successful!");
                this.Hide();
                Form5 fm = new Form5();
                fm.Show();
            }else
            {
                MessageBox.Show("Check your Username and Password");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
