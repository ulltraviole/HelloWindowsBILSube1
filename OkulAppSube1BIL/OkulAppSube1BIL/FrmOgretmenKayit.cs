using OkulApp.BLL;
using OkulApp.MODEL;
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

namespace OkulAppSube1BIL
{
    public partial class FrmOgretmenKayit : Form
    {
        public int OgretmenId { get; set; }
        public FrmOgretmenKayit()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgretmenBL();
                bool sonuc = obl.OgretmenEkle(new Ogretmen { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), TCKimlikNumarasi = txtTCKN.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme Başarılı!" : "Ekleme Başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numaralı öğretmen daha önce kayıtlı");
                        break;
                    default:
                        MessageBox.Show("Veritabanı hatası");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmeyen Hata!!");
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            FrmOgretmenBul frm = new FrmOgretmenBul(this);
            frm.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgretmenBL();
                bool sonuc = obl.OgretmenGuncelle(new Ogretmen { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), TCKimlikNumarasi = txtTCKN.Text.Trim(), OgretmenId = OgretmenId });
                MessageBox.Show(sonuc ? "Güncelleme başarılı." : "Güncelleme başarısız.");
                if (sonuc) { btnGuncelle.Enabled = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgretmenBL();
                bool sonuc = obl.OgretmenSil(OgretmenId);
                MessageBox.Show(sonuc ? "Silme başarılı" : "Silme başarısız.");
                if (sonuc) { btnSil.Enabled = false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}