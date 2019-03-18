using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*

CodeFirst ile SQL içinde veritabanı oluşacak. Bu veritabanına bağlı 2 adet tablo ve bunların kolonları oluşacak.
Form1'deki menustriplerden "Sınıfların Tanımlanması"na tıklanıldığında FormSinif formuna, "Öğrencilerin Tanımlanması"na tıklanıldığında
FormOgrenci formuna aktarılacak. 
FormSinif formunda textboxa girilen sınıflar ekle butonuna tıklanmasıyla tablosuna eklenip, databasede gösterilip veritabanında tutulacak.
FormOgrenci formunda comboboxtan veritabanında varolan sınıflar seçilip ilgili textboxa Ad Soyad girilip ekle butonuna tıklanıldığında
tablosuna eklenip veritabanında tutulacak ve dataGridviewda gösterilecek.
Bu işlemlerden sonra da migrations yapılacak.

    Mevcut ile geliştirilmiş database'i kıyaslayıp farkları bulur. Farkları barındıran düzenleme kodlarını oluşturur.
    */




//APP.CONFİG'de
//"data source=WISSEN\MSSQLSRV;initial catalog=Mart18Database;integrated"
//data source kısmında tabloyu oluşturmak istediğiniz server'i, initial catalog kısmında oluşturacağımız database'in ismini yazıyoruz.

namespace CodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sınıflarınTanımlanmasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSinif frm1 = new FormSinif();
            frm1.Show();
        }

        private void öğrencilerinTanımlanmasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOgrenci frm = new FormOgrenci();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
