namespace AspNetMvc.QuickStart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Annotation_Name_Major9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Softwares", "Type", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Softwares", "Type", c => c.String(nullable: false, maxLength: 4));
        }
    }
}
