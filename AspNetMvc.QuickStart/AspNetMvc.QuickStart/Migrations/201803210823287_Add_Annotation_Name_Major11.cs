namespace AspNetMvc.QuickStart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Annotation_Name_Major11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Softwares", "Description", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Softwares", "Description", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
