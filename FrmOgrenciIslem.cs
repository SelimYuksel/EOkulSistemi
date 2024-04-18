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
    public partial class FrmOgrenciIslem : Form
    {
        public FrmOgrenciIslem()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-5CQC2MM;Initial Catalog=OkulProje;Integrated Security=True");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen frmOgretmen = new FrmOgretmen();
            frmOgretmen.Show();
            this.Hide();
        }

        DataSet1TableAdapters.TBLOGRENCILERTableAdapter dataset = new DataSet1TableAdapters.TBLOGRENCILERTableAdapter(); //Öğrenci veri işlemleri için kullanılacak sorguları barındıran metotlar

        private void FrmOgrenciIslem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataset.OgrenciListele();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLKULUPLER", connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            CmbKulup.DisplayMember = "KULUPAD";
            CmbKulup.ValueMember = "KULUPID";
            CmbKulup.DataSource = dataTable;
            connection.Close();
            
        }
        string seciliCinsiyet = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            dataset.OgrenciEkle(TxtOgrenciAd.Text,TxtOgrenciSoyad.Text,byte.Parse(CmbKulup.SelectedValue.ToString()),seciliCinsiyet);
            MessageBox.Show("Öğrenci ekleme işlemi başarıyla tamamlandı!");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataset.OgrenciListele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            dataset.OgrenciSil(int.Parse(TxtOgrenciId.Text)); //Notlar tablosundaki ogrid yabancı anahtarı özelliklerinde CASCADE DELETE yoksa silme işlemi gerçekleşmez
            MessageBox.Show(TxtOgrenciId.Text + " Numaralı öğrenci silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Erkek")  
            {
                radioButton2.Checked = true;
            }
            if(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Kadın")
            {
                radioButton1.Checked = true;
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            dataset.OgrenciGuncelle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), seciliCinsiyet,int.Parse(TxtOgrenciId.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                seciliCinsiyet = "Kadın";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                seciliCinsiyet = "Erkek";
            }
        }

        private void BtnArama_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataset.OgrenciGetir(TxtArama.Text);
        }
    }
}
