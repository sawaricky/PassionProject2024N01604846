namespace PassionProject2024N01604846.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instructorFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.InstrumentLessons", "InstructorId");
            AddForeignKey("dbo.InstrumentLessons", "InstructorId", "dbo.Instructors", "InstructorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstrumentLessons", "InstructorId", "dbo.Instructors");
            DropIndex("dbo.InstrumentLessons", new[] { "InstructorId" });
        }
    }
}
