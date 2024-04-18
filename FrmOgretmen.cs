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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void BtnKulup_Click(object sender, EventArgs e)
        {
            FrmKulup frmKulup = new FrmKulup();
            frmKulup.Show();
            

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Show();
            this.Hide();
            
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersler frmDersler = new FrmDersler();
            frmDersler.Show();
            
        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenciIslem frmOgrenciIslem = new FrmOgrenciIslem();
            frmOgrenciIslem.Show();
            
        }

        private void BtnSinav_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frmSinavNotlar = new FrmSinavNotlar();
            frmSinavNotlar.Show();
        }
    }
}
