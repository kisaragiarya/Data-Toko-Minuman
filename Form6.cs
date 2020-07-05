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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EJH2D6F\\ARYA;Initial Catalog=finalPABD;User ID=sa;Password=arya@cool123;");

        public Form6()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO login VALUES (@UserId, @Pword)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserId", textBoxID.Text);
            cmd.Parameters.AddWithValue("@Pword", textBoxNama.Text);
           

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sukses", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fm = new Form5();
            fm.Show();
        }
    }
}
