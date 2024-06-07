namespace PassionProject2024N01604846.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Academylessonmm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstrumentLessonAcademies",
                c => new
                    {
                        InstrumentLesson_LessonID = c.Int(nullable: false),
                        Academy_AcademyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstrumentLesson_LessonID, t.Academy_AcademyId })
                .ForeignKey("dbo.InstrumentLessons", t => t.InstrumentLesson_LessonID, cascadeDelete: true)
                .ForeignKey("dbo.Academies", t => t.Academy_AcademyId, cascadeDelete: true)
                .Index(t => t.InstrumentLesson_LessonID)
                .Index(t => t.Academy_AcademyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstrumentLessonAcademies", "Academy_AcademyId", "dbo.Academies");
            DropForeignKey("dbo.InstrumentLessonAcademies", "InstrumentLesson_LessonID", "dbo.InstrumentLessons");
            DropIndex("dbo.InstrumentLessonAcademies", new[] { "Academy_AcademyId" });
            DropIndex("dbo.InstrumentLessonAcademies", new[] { "InstrumentLesson_LessonID" });
            DropTable("dbo.InstrumentLessonAcademies");
        }
    }
}
