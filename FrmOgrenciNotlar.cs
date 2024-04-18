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
        public string tcno;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCommand1 = new SqlCommand("SELECT DERSAD, SINAV1, SINAV2, PROJE, ORTALAMA, DURUM, OGRTCNO, OGRAD, OGRSOYAD\r\nFROM TBLNOTLAR\r\nINNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID\r\nINNER JOIN TBLOGRENCILER ON TBLNOTLAR.OGRID = TBLOGRENCILER.OGRID\r\nWHERE OGRTCNO=@P1", connection);
            sqlCommand1.Parameters.AddWithValue("@P1",tcno);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand1);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
