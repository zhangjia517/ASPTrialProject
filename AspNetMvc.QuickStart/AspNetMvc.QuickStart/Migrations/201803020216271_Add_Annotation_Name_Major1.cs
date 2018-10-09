namespace AspNetMvc.QuickStart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Annotation_Name_Major1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Major", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Major", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
