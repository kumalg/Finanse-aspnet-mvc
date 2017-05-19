namespace Finanse_aspnet_mvc.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryBases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ColorKey = c.String(),
                        IconKey = c.String(),
                        VisibleInIncomes = c.Boolean(nullable: false),
                        VisibleInExpenses = c.Boolean(nullable: false),
                        CantDelete = c.Boolean(nullable: false),
                        ParentCategoryId = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        VisibleInStatistics = c.Boolean(nullable: false),
                        Title = c.String(maxLength: 64),
                        MoreInfo = c.String(maxLength: 1024),
                        CategoryId = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsExpense = c.Boolean(nullable: false),
                        MoneyAccountId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryBases", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operations", "CategoryId", "dbo.CategoryBases");
            DropIndex("dbo.Operations", new[] { "CategoryId" });
            DropTable("dbo.Operations");
            DropTable("dbo.CategoryBases");
        }
    }
}
