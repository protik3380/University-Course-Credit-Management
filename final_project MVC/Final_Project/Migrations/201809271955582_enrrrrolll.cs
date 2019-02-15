namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrrrrolll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnrollCourse", "IsEnroll", c => c.Boolean(nullable: false));
            DropColumn("dbo.Course", "IsEnroll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "IsEnroll", c => c.Boolean(nullable: false));
            DropColumn("dbo.EnrollCourse", "IsEnroll");
        }
    }
}
