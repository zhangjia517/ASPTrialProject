namespace AspNetMvc.QuickStart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Annotation_Name_Major14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Softwares", "Type", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Softwares", "URL", c => c.String(maxLength: 800));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Softwares", "URL", c => c.String(nullable: false, maxLength: 800));
            AlterColumn("dbo.Softwares", "Type", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
