namespace Finanse_aspnet_mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yco : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OperationPatterns", newName: "Operations");
            DropIndex("dbo.Operations", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Operations");
            CreateTable(
                "dbo.OperationPatterns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 64),
                        MoreInfo = c.String(maxLength: 1024),
                        CategoryId = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsExpense = c.Boolean(nullable: false),
                        MoneyAccountId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CategoryId);
            
            AlterColumn("dbo.Operations", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Operations", "VisibleInStatistics", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.Operations", "Id");
            CreateIndex("dbo.Operations", "Id");
            //AddForeignKey("dbo.Operations", "Id", "dbo.OperationPatterns", "Id");
            //DropColumn("dbo.Operations", "Title");
            //DropColumn("dbo.Operations", "MoreInfo");
            //DropColumn("dbo.Operations", "CategoryId");
            //DropColumn("dbo.Operations", "Cost");
            //DropColumn("dbo.Operations", "IsExpense");
            //DropColumn("dbo.Operations", "MoneyAccountId");
            DropColumn("dbo.Operations", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Operations", "MoneyAccountId", c => c.String());
            AddColumn("dbo.Operations", "IsExpense", c => c.Boolean(nullable: false));
            AddColumn("dbo.Operations", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Operations", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Operations", "MoreInfo", c => c.String(maxLength: 1024));
            AddColumn("dbo.Operations", "Title", c => c.String(maxLength: 64));
            DropForeignKey("dbo.Operations", "Id", "dbo.OperationPatterns");
            DropIndex("dbo.Operations", new[] { "Id" });
            DropIndex("dbo.OperationPatterns", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Operations");
            AlterColumn("dbo.Operations", "VisibleInStatistics", c => c.Boolean());
            AlterColumn("dbo.Operations", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.OperationPatterns");
            AddPrimaryKey("dbo.Operations", "Id");
            CreateIndex("dbo.Operations", "CategoryId");
            RenameTable(name: "dbo.Operations", newName: "OperationPatterns");
        }
    }
}
