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
    public partial class FormSinif : Form
    {
        OgrenciSinif ctx = new OgrenciSinif();
        public FormSinif()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Sinif s = new Sinif(); // Sinif entitysinden s adında instance aldık.
            s.Aciklama = txtAciklama.Text;//Açklama dediğimiz şey aslında sınıf adı
            ctx.Siniflar.Add(s);// ismi s olan entity'yi Siniflar facade'ının içine atıyoruz.
            ctx.SaveChanges(); // Yaptığımız işlemleri database'e işler.
            Doldur(); // Doldur metodunu çağırdık.
        }

        private void FormSinif_Load(object sender, EventArgs e)
        {
            Doldur();
        }
        private void Doldur()// FormSinif formundaki datagridview'ı doldurduk
        {
            dataGridViewSinif.DataSource = ctx.Siniflar.Select(x => new
            {
                x.SinifID,
                x.Aciklama
            }).ToList();


        }
    }
}
