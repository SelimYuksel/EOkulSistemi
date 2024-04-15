using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5CQC2MM;Initial Catalog=OkulProje;Integrated Security=True");

        void Liste()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM TBLKULUPLER", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            Liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen frmOgretmen = new FrmOgretmen();
            frmOgretmen.Show();
            this.Hide();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TBLKULUPLER (KULUPAD) VALUES (@p1)", connection);
            sqlCommand.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kulüp eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromArgb(102,221,170);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM TBLKULUPLER WHERE KULUPID=@p1", connection);
            sqlCommand.Parameters.AddWithValue("@p1", TxtKulupId);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kulüp silme işlemi gerçekleşti");
            Liste();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE TBLKULUPLER SET KULUPAD=@p1 WHERE KULUPID=@p2", connection);
            sqlCommand.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            sqlCommand.Parameters.AddWithValue("@p2", TxtKulupId.Text);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kulüp güncelleme işlemi gerçekleşti");
            Liste();
        }
    }
}
