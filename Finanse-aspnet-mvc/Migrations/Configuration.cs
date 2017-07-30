using Finanse_aspnet_mvc.Models.Categories;

namespace Finanse_aspnet_mvc.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.StackMoneyDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.StackMoneyDb context) {
            var defaultCategory = new Category {
                Id = 1,
                CantDelete = true,
                Name = "Inne",
                ColorKey = "1",
                IconKey = "1"
            };
            context.Categories.AddOrUpdate(h => h.Id, defaultCategory);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
