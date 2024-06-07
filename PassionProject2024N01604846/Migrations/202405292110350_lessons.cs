namespace PassionProject2024N01604846.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lessons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstrumentLessons",
                c => new
                    {
                        LessonID = c.Int(nullable: false, identity: true),
                        LessonName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LessonID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InstrumentLessons");
        }
    }
}
