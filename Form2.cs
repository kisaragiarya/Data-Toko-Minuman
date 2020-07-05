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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EJH2D6F\\ARYA;Initial Catalog=finalPABD;User ID=sa;Password=arya@cool123;");
        public int idMinuman;
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        
        public Form2()
        {
            InitializeComponent();
            SearchData("");
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalPABDDataSet.minuman' table. You can move, or remove it, as needed.
            this.minumanTableAdapter.Fill(this.finalPABDDataSet.minuman);

        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idMinuman = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            SetValueForText1 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            SetValueForText2 = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            SetValueForText3 = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            SetValueForText4 = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            SetValueForText5 = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

 
        }

        public void SearchData(string valueToSearch)
        {
            string query = "SELECT * FROM minuman WHERE idMinuman LIKE '%" + valueToSearch + "%' OR namaMinuman LIKE '%" + valueToSearch + "%'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if(idMinuman > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM minuman WHERE idMinuman = @idMinuman", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("idMinuman", this.idMinuman);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Sukses", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("gagal");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fm = new Form4();
            fm.Show();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SearchData("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxSearch.Text.ToString();
            SearchData(valueToSearch);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fm = new Form5();
            fm.Show();
        }
    }
}
