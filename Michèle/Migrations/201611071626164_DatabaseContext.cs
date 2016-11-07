namespace Michèle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        PinterestUrl = c.String(),
                        VkUrl = c.String(),
                        BehanceUrl = c.String(),
                        WorkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Works", t => t.WorkID, cascadeDelete: true)
                .Index(t => t.WorkID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderID = c.Int(nullable: false, identity: true),
                        SliderPCUrl = c.String(),
                        SlideTouchPadrUrl = c.String(),
                        SlidePhoneUrl = c.String(),
                        WorkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SliderID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        RoleId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.WorkLangs",
                c => new
                    {
                        WorkLangID = c.Int(nullable: false, identity: true),
                        WorkID = c.Int(nullable: false),
                        WorkName = c.String(),
                        Describe = c.String(),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkLangID)
                .ForeignKey("dbo.Languages", t => t.LanguageID, cascadeDelete: true)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        WorkID = c.Int(nullable: false, identity: true),
                        MainPhoto = c.String(),
                        Slider_SliderID = c.Int(),
                    })
                .PrimaryKey(t => t.WorkID)
                .ForeignKey("dbo.Sliders", t => t.Slider_SliderID)
                .Index(t => t.Slider_SliderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "Slider_SliderID", "dbo.Sliders");
            DropForeignKey("dbo.Photos", "WorkID", "dbo.Works");
            DropForeignKey("dbo.WorkLangs", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Works", new[] { "Slider_SliderID" });
            DropIndex("dbo.WorkLangs", new[] { "LanguageID" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Photos", new[] { "WorkID" });
            DropTable("dbo.Works");
            DropTable("dbo.WorkLangs");
            DropTable("dbo.Users");
            DropTable("dbo.Sliders");
            DropTable("dbo.Roles");
            DropTable("dbo.Photos");
            DropTable("dbo.Languages");
            DropTable("dbo.Categories");
        }
    }
}
