namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotEklemeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogrenci", "Notlar", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ogrenci", "Notlar");
        }
    }
}
