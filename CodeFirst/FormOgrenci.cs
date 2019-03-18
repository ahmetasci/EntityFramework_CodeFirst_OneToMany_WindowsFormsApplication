using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
{
    public partial class FormOgrenci : Form
    {
        OgrenciSinif ctx = new OgrenciSinif();
        public FormOgrenci()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            ogr.AdSoyad = txtAdSoyad.Text;
            ogr.SinifID = (int)cmbSinif.SelectedValue;
            ctx.Ogrenciler.Add(ogr);
            ctx.SaveChanges();
            Doldur();
        }
        private void Doldur()
        {
            dataGridViewOgrenci.DataSource = ctx.Ogrenciler.Select(x => new
            {
                x.TcKimlikID,
                x.AdSoyad,
                x.sinif.Aciklama

            }).ToList();
        }
        private void cmbDoldur()
        {
            var clist = ctx.Siniflar.Select(x => new
            {

                x.SinifID,
                x.Aciklama
            }).ToList();

            cmbSinif.DisplayMember = "Aciklama";
            cmbSinif.ValueMember = "SinifID";
            cmbSinif.DataSource = clist;


        }

        private void FormOgrenci_Load(object sender, EventArgs e)
        {
            cmbDoldur();
            Doldur();
        }
    }
}
