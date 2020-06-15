namespace DataAnnotattion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelVersionOne : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Courses", newName: "CoursesDetail");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CoursesDetail", newName: "Courses");
        }
    }
}
