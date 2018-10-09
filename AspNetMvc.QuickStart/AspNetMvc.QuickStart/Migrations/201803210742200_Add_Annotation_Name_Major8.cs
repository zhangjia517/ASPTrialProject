namespace AspNetMvc.QuickStart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Annotation_Name_Major8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Softwares", "Description", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Softwares", "Type", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Softwares", "Type");
            DropColumn("dbo.Softwares", "Description");
        }
    }
}
