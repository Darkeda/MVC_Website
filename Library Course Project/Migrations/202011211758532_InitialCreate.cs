namespace Library_Course_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.WriterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Writers");
            DropTable("dbo.Genres");
        }
    }
}
