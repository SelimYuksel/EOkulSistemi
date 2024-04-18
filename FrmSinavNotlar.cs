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
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5CQC2MM;Initial Catalog=OkulProje;Integrated Security=True");

        DataSet1TableAdapters.TBLNOTLARTableAdapter dataset = new DataSet1TableAdapters.TBLNOTLARTableAdapter();

        private void BtnGetir_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataset.NotListele(int.Parse(TxtOgrenciId.Text));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen frmOgretmen = new FrmOgretmen();
            frmOgretmen.Show();
            this.Hide();
        }

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLDERSLER", connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            CmbDers.DisplayMember = "DERSAD";
            CmbDers.ValueMember = "DERSID";
            CmbDers.DataSource = dataTable;
            connection.Close();
        }

        int notid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        int s1, s2, proje;
        double ort;

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            s1 = Convert.ToInt16(TxtSinav1.Text);
            s2 = Convert.ToInt16(TxtSinav2.Text);
            proje = Convert.ToInt16(TxtProje.Text);

            ort = s1 * 0.2 + s2 * 0.6 + proje * 0.2;

            TxtOrt.Text = ort.ToString();

            if(ort >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            dataset.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(TxtOgrenciId.Text), byte.Parse(TxtSinav1.Text.ToString()), byte.Parse(TxtSinav2.Text.ToString()), byte.Parse(TxtProje.Text.ToString()), decimal.Parse(TxtOrt.Text.ToString()), bool.Parse(TxtDurum.Text), notid);
        }
    }
}
