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

namespace SchoolProject
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5CQC2MM;Initial Catalog=OkulProje;Integrated Security=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand1 = new SqlCommand("SELECT DERSAD, SINAV1, SINAV2, PROJE, ORTALAMA, DURUM FROM TBLNOTLAR\r\nINNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID=@P1", connection);
            sqlCommand1.Parameters.AddWithValue("@P1",numara);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand1);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            SqlCommand sqlCommand2 = new SqlCommand("SELECT OGRAD, OGRSOYAD FROM TBLOGRENCILER WHERE OGRID=@P2", connection);
            sqlCommand2.Parameters.AddWithValue("@P2", numara);

            connection.Open();

            SqlDataReader dataReader = sqlCommand2.ExecuteReader();
            if (dataReader.Read())
            {
                string ad = dataReader["OGRAD"].ToString();
                string soyad = dataReader["OGRSOYAD"].ToString();
                this.Text = ad + " " + soyad;
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı");
            }
            connection.Close();


        }
    }
}
