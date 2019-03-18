namespace CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations; //Tablolarla ilgili k�s�tlar (anotey�in)
    using System.ComponentModel.DataAnnotations.Schema;//Schemalarla ilgili k�s�tlar
    using System.Data.Entity;
    using System.Linq;

    public class OgrenciSinif : DbContext
    {
       
        public OgrenciSinif()
            : base("name=OgrenciSinif")
        {
        }

        public virtual DbSet<Ogrenci> Ogrenciler { get; set; }
        //Ogrenci entitysinden Ogrenciler Facade'� olu�turduk
        public virtual DbSet<Sinif> Siniflar { get; set; }
        //Sinif entitysinden Siniflar Facade'� olu�turduk.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
    //Yukar�da tasla��n� olu�turdu�umuz Ogrenci clas�n�n i�ini dolduruyoruz.
    [Table("Ogrenci")] // Buradaki ismi ne olursa olsun tablonun ismi SQL'de Ogrenci olacak.
    public class Ogrenci
    {
        //Key yazarsak primary key oldu�unu belirtiyoruz.TCKimlikID art�k bizim primary key'imiz.
        [Key]
        public long TcKimlikID { get; set; }

        [StringLength(80)] //AdSoyad max 80 karakterden olu�ur.Stringler i�in kullan�l�r.String ifadeler i�in StringLength kullan�l�r. Genel anlamda MaxLength
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ad Soyad Bo� Olamaz")]//Hata mesaj� tan�mlad�k.AdSoyad alan�n�n bo� ge�ilmeyece�ini belirtir.
        public string AdSoyad { get; set; }
        public int Yas { get; set; }
        public int SinifID { get; set; }
        public int Notlar { get; set; }
        public virtual Sinif sinif { get; set; }
        //Bir ��renci bir s�n�fta olabilir.  G�sterimi bu �ekilde 
        //Birebir ili�ki.
    }
    //Yukar�da tasla��n� olu�turdu�umuz Sinif clas�n�n i�ini dolduruyoruz.
    [Table("Sinif")]//Bu s�n�f�n tablo ad� Sinif olacak. (DataAnnotations)
    public class Sinif
    {
        public Sinif()
        {
            this.ogrenciler = new HashSet<Ogrenci>();//Performans�n� art�r�yor.
            //ICollection tan�mland���nda hemen bir constructor a��l�r ve bu i�lem performans� artt�r�r.

        }
        [Key]
        public int SinifID { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<Ogrenci> ogrenciler { get; set; }
        //Buna navigation property denir.
        //Bir s�n�fta birden �ok ��renci olabilir. G�sterimi bu �ekilde 
        //Bire�ok ili�ki 


        /*
         * Bir ��renci bir s�n�fta olabilir. 
         * Bir s�n�fta birden �ok ��renci olabilir.
         * */
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}