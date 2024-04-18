using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject
{
    public partial class FrmOgrenciSifre : Form
    {
        public FrmOgrenciSifre()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5CQC2MM;Initial Catalog=OkulProje;Integrated Security=True");

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO TBLOGRENCILER (OGRTCNO, OGRSIFRE) VALUES (@p1,@p2)", connection);
            command.Parameters.AddWithValue("@p1", MskNo.Text);
            command.Parameters.AddWithValue("@p2", TxtSifre.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Şifreniz oluşturuldu");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Show();
            this.Hide();
        }
    }
}
