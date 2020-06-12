namespace DataAnnotattion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        FullPrice = c.Single(nullable: false),
                        authorId = c.Int(nullable: false),
                        description = c.String(nullable: false, maxLength: 2000),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.authorId)
                .Index(t => t.authorId);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo._Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTag",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.TagID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTag", "TagID", "dbo.Tags");
            DropForeignKey("dbo.CourseTag", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Covers", "ID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "authorId", "dbo.Authors");
            DropIndex("dbo.CourseTag", new[] { "TagID" });
            DropIndex("dbo.CourseTag", new[] { "CourseID" });
            DropIndex("dbo.Covers", new[] { "ID" });
            DropIndex("dbo.Courses", new[] { "authorId" });
            DropTable("dbo.CourseTag");
            DropTable("dbo._Categories");
            DropTable("dbo.Tags");
            DropTable("dbo.Covers");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
