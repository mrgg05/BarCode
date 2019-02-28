namespace BarkodSistem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "BitmapKayit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "BitmapKayit");
        }
    }
}
