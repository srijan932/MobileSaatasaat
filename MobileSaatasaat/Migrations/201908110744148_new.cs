namespace MobileSaatasaat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostVMs",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        Image = c.String(),
                        ImageOfBox = c.String(),
                        ImageOfMobile = c.String(),
                        Price = c.String(),
                        FullName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
            AddColumn("dbo.Posts", "FullName", c => c.String());
            AddColumn("dbo.Posts", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Phone");
            DropColumn("dbo.Posts", "FullName");
            DropTable("dbo.PostVMs");
        }
    }
}
