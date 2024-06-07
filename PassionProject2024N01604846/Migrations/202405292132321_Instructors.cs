namespace PassionProject2024N01604846.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Instructors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        InstructorNumber = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        Wages = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InstructorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Instructors");
        }
    }
}
