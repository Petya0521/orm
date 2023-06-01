namespace FruitsOrm10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fruits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TypeId = c.String(),
                        Price = c.Double(nullable: false),
                        FruitTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FruitTypes", t => t.FruitTypeId, cascadeDelete: true)
                .Index(t => t.FruitTypeId);
            
            CreateTable(
                "dbo.FruitTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fruits", "FruitTypeId", "dbo.FruitTypes");
            DropIndex("dbo.Fruits", new[] { "FruitTypeId" });
            DropTable("dbo.FruitTypes");
            DropTable("dbo.Fruits");
        }
    }
}
