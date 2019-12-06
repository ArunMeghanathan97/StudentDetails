namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentsId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentsId);

            CreateTable(
                "dbo.Address",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Street = c.String(nullable: false),
                    City = c.String(nullable: false),
                    State = c.String(nullable: false),
                    Country = c.String(nullable: false),
                    StudentsId = c.Int(nullable:false),
                })
                .PrimaryKey(t => t.Id);            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
