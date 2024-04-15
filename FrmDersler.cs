using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBLDERSLERTableAdapter dataset = new DataSet1TableAdapters.TBLDERSLERTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = dataset.DersListesi();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            dataset.DersEkle(TxtDersAd.Text);
            MessageBox.Show("Ders ekleme işlemi tamamlandı.");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataset.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen frmOgretmen = new FrmOgretmen();
            frmOgretmen.Show();
            this.Hide();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            dataset.DersSil(Byte.Parse(TxtDersId.Text)); //Ders id'si db'de tinyint türünde belirtildiği için
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            dataset.DersGuncelle(TxtDersAd.Text, Byte.Parse(TxtDersId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromArgb(102, 221, 170);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }
    }
}
