namespace PassionProject2024N01604846.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Academy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Academies",
                c => new
                    {
                        AcademyId = c.Int(nullable: false, identity: true),
                        AcademyName = c.String(),
                        AcademyAddress = c.String(),
                    })
                .PrimaryKey(t => t.AcademyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Academies");
        }
    }
}
