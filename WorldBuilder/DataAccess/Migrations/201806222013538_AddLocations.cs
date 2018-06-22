namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterLocationAssociations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Character_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Character_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterLocationAssociations", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.CharacterLocationAssociations", "Character_Id", "dbo.Characters");
            DropIndex("dbo.CharacterLocationAssociations", new[] { "Location_Id" });
            DropIndex("dbo.CharacterLocationAssociations", new[] { "Character_Id" });
            DropTable("dbo.Locations");
            DropTable("dbo.CharacterLocationAssociations");
        }
    }
}
