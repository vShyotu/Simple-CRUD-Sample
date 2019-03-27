namespace Sample_Project_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEdited : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageEntries", "Edited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessageEntries", "Edited");
        }
    }
}
