namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollunassign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "IsEnroll", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "IsEnroll");
        }
    }
}
