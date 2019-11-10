namespace MobileSaatasaat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post_createdby : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CreatedBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "CreatedBy");
        }
    }
}
