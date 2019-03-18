namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogrenci",
                c => new
                    {
                        TcKimlikID = c.Long(nullable: false, identity: true),
                        AdSoyad = c.String(nullable: false, maxLength: 80),
                        Yas = c.Int(nullable: false),
                        SinifID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TcKimlikID)
                .ForeignKey("dbo.Sinif", t => t.SinifID, cascadeDelete: true)
                .Index(t => t.SinifID);
            
            CreateTable(
                "dbo.Sinif",
                c => new
                    {
                        SinifID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.SinifID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrenci", "SinifID", "dbo.Sinif");
            DropIndex("dbo.Ogrenci", new[] { "SinifID" });
            DropTable("dbo.Sinif");
            DropTable("dbo.Ogrenci");
        }
    }
}
