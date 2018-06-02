namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCharacterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Characters", "Gender_Id", c => c.Int());
            AddColumn("dbo.Characters", "Race_Id", c => c.Int());
            CreateIndex("dbo.Characters", "Gender_Id");
            CreateIndex("dbo.Characters", "Race_Id");
            AddForeignKey("dbo.Characters", "Gender_Id", "dbo.Genders", "Id");
            AddForeignKey("dbo.Characters", "Race_Id", "dbo.Races", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Characters", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Characters", new[] { "Race_Id" });
            DropIndex("dbo.Characters", new[] { "Gender_Id" });
            DropColumn("dbo.Characters", "Race_Id");
            DropColumn("dbo.Characters", "Gender_Id");
            DropTable("dbo.Races");
            DropTable("dbo.Genders");
        }
    }
}
