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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EJH2D6F\\ARYA;Initial Catalog=finalPABD;User ID=sa;Password=arya@cool123;");
        public Form4()
        {
            InitializeComponent();
            textBoxID.Text = Form2.SetValueForText1;
            textBoxNama.Text = Form2.SetValueForText2;
            textBoxStock.Text = Form2.SetValueForText3;
            textBoxHarga.Text = Form2.SetValueForText4;
            textBoxTerjual.Text = Form2.SetValueForText5;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE minuman SET namaMinuman = @namaMinuman,stock = @stock,hargaMinuman = @hargaMinuman,terjual = @terjual WHERE idMinuman = @idMinuman", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@idMinuman", textBoxID.Text);
            cmd.Parameters.AddWithValue("@namaMinuman", textBoxNama.Text);
            cmd.Parameters.AddWithValue("@stock", textBoxStock.Text);
            cmd.Parameters.AddWithValue("@hargaMinuman", textBoxHarga.Text);
            cmd.Parameters.AddWithValue("@terjual", textBoxTerjual.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sukses", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fm = new Form2();
            fm.Show();
        }
    }
}
