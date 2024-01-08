using OkulApp.BLL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulAppSube1BIL
{
    public partial class FrmOgretmenBul : Form
    {
        FrmOgretmenKayit frm;
        public FrmOgretmenBul(FrmOgretmenKayit frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgretmenBL();
                Ogretmen ogr = obl.OgretmenBul(txtOgretmenTCKN.Text.Trim());
                if (ogr != null)
                {
                    frm.txtAd.Text = ogr.Ad;
                    frm.txtSoyad.Text = ogr.Soyad;
                    frm.txtTCKN.Text = ogr.TCKimlikNumarasi;
                    frm.OgretmenId = ogr.OgretmenId;
                    frm.btnGuncelle.Enabled = true;
                    frm.btnSil.Enabled = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
