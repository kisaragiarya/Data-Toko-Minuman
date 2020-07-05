using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EJH2D6F\\ARYA;Initial Catalog=finalPABD;User ID=sa;Password=arya@cool123;");
        public Form3()
        {
            InitializeComponent();
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO minuman VALUES (@idMinuman, @namaMinuman, @stock, @hargaMinuman, @terjual)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idMinuman", textBoxID.Text);
                cmd.Parameters.AddWithValue("@namaMinuman", textBoxNama.Text);
                cmd.Parameters.AddWithValue("@stock", textBoxStock.Text);
                cmd.Parameters.AddWithValue("@hargaMinuman", textBoxHarga.Text);
                cmd.Parameters.AddWithValue("@terjual", textBoxTerjual.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Sukses","Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool isValid()
        {
            if(textBoxID.Text == string.Empty)
            {
                MessageBox.Show("ID Minuman is Required");
                return false;
            }
            return true;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalPABDDataSet.minuman' table. You can move, or remove it, as needed.
            this.minumanTableAdapter.Fill(this.finalPABDDataSet.minuman);

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fm = new Form2();
            fm.Show();
        }
    }
}
