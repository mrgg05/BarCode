namespace BarkodSistem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aak : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "BitmapKayit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "BitmapKayit", c => c.String());
        }
    }
}
