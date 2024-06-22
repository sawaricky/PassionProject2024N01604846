namespace PassionProject2024N01604846.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropNOFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Academies", "InstrumentLesson_LessonID", "dbo.InstrumentLessons");
            DropIndex("dbo.Academies", new[] { "InstrumentLesson_LessonID" });
            DropColumn("dbo.Academies", "InstrumentLesson_LessonID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Academies", "InstrumentLesson_LessonID", c => c.Int());
            CreateIndex("dbo.Academies", "InstrumentLesson_LessonID");
            AddForeignKey("dbo.Academies", "InstrumentLesson_LessonID", "dbo.InstrumentLessons", "LessonID");
        }
    }
}
