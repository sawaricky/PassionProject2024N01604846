namespace PassionProject2024N01604846.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstructorId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstrumentLessons", "InstructorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstrumentLessons", "InstructorId");
        }
    }
}
