namespace AspNetMvc.QuickStart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Annotation_Name_Major3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Students", "Major", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Major", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
