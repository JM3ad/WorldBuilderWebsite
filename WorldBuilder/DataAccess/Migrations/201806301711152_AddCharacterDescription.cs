namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCharacterDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Description");
        }
    }
}
