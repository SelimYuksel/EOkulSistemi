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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5CQC2MM;Initial Catalog=OkulProje;Integrated Security=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM TBLOGRENCILER WHERE OGRTCNO=@p1 AND OGRSIFRE=@p2", connection);
            command.Parameters.AddWithValue("@p1", MskNo.Text);
            command.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read()) //Eğer kimlik bilgisi ve şifre, veri tabanındaki bilgilerle uyuşuyorsa
            {
                FrmOgrenciNotlar frm = new FrmOgrenciNotlar();
                frm.tcno = MskNo.Text;
                frm.Show();
            }
            else //uyuşmuyorsa
            {
                MessageBox.Show("Hatalı TC No ya da şifre");
            }
            connection.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM TBLOGRETMENLER WHERE OGRTTCNO=@p1 AND OGRTSIFRE=@p2", connection);
            command.Parameters.AddWithValue("@p1", MskNo.Text);
            command.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read()) //Eğer kimlik bilgisi ve şifre, veri tabanındaki bilgilerle uyuşuyorsa
            {
                FrmOgretmen frmOgretmen = new FrmOgretmen();
                frmOgretmen.Show();
                this.Hide();
            }
            else //uyuşmuyorsa
            {
                MessageBox.Show("Hatalı TC No ya da şifre");
            }
            connection.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
