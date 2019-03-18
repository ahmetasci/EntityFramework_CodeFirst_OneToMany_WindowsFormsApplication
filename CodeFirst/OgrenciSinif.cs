namespace CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations; //Tablolarla ilgili kýsýtlar (anoteyþin)
    using System.ComponentModel.DataAnnotations.Schema;//Schemalarla ilgili kýsýtlar
    using System.Data.Entity;
    using System.Linq;

    public class OgrenciSinif : DbContext
    {
       
        public OgrenciSinif()
            : base("name=OgrenciSinif")
        {
        }

        public virtual DbSet<Ogrenci> Ogrenciler { get; set; }
        //Ogrenci entitysinden Ogrenciler Facade'ý oluþturduk
        public virtual DbSet<Sinif> Siniflar { get; set; }
        //Sinif entitysinden Siniflar Facade'ý oluþturduk.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
    //Yukarýda taslaðýný oluþturduðumuz Ogrenci clasýnýn içini dolduruyoruz.
    [Table("Ogrenci")] // Buradaki ismi ne olursa olsun tablonun ismi SQL'de Ogrenci olacak.
    public class Ogrenci
    {
        //Key yazarsak primary key olduðunu belirtiyoruz.TCKimlikID artýk bizim primary key'imiz.
        [Key]
        public long TcKimlikID { get; set; }

        [StringLength(80)] //AdSoyad max 80 karakterden oluþur.Stringler için kullanýlýr.String ifadeler için StringLength kullanýlýr. Genel anlamda MaxLength
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ad Soyad Boþ Olamaz")]//Hata mesajý tanýmladýk.AdSoyad alanýnýn boþ geçilmeyeceðini belirtir.
        public string AdSoyad { get; set; }
        public int Yas { get; set; }
        public int SinifID { get; set; }
        public int Notlar { get; set; }
        public virtual Sinif sinif { get; set; }
        //Bir öðrenci bir sýnýfta olabilir.  Gösterimi bu þekilde 
        //Birebir iliþki.
    }
    //Yukarýda taslaðýný oluþturduðumuz Sinif clasýnýn içini dolduruyoruz.
    [Table("Sinif")]//Bu sýnýfýn tablo adý Sinif olacak. (DataAnnotations)
    public class Sinif
    {
        public Sinif()
        {
            this.ogrenciler = new HashSet<Ogrenci>();//Performansýný artýrýyor.
            //ICollection tanýmlandýðýnda hemen bir constructor açýlýr ve bu iþlem performansý arttýrýr.

        }
        [Key]
        public int SinifID { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<Ogrenci> ogrenciler { get; set; }
        //Buna navigation property denir.
        //Bir sýnýfta birden çok öðrenci olabilir. Gösterimi bu þekilde 
        //BireÇok iliþki 


        /*
         * Bir öðrenci bir sýnýfta olabilir. 
         * Bir sýnýfta birden çok öðrenci olabilir.
         * */
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}