namespace MisaShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RefDetails",
                c => new
                    {
                        RefDetailID = c.Guid(nullable: false, defaultValueSql: "newid()", identity: true),
                        Description = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        collectionType = c.String(),
                        RefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RefDetailID)
                .ForeignKey("dbo.Refs", t => t.RefId, cascadeDelete: true)
                .Index(t => t.RefId);
            
            CreateTable(
                "dbo.Refs",
                c => new
                    {
                        RefId = c.Guid(nullable: false, defaultValueSql: "newid()", identity: true),
                        RefDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                        RefNo = c.String(),
                        RefType = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContactName = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.RefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RefDetails", "RefId", "dbo.Refs");
            DropIndex("dbo.RefDetails", new[] { "RefId" });
            DropTable("dbo.Refs");
            DropTable("dbo.RefDetails");
        }
    }
}
