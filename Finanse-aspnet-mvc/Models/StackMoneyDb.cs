using System.Collections.Generic;
using System.Data.Entity;
using Finanse_aspnet_mvc.Models.Categories;
using Finanse_aspnet_mvc.Models.Operations;

namespace Finanse_aspnet_mvc.Models {
    public class StackMoneyDb : DbContext {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationPattern> Patterns { get; set; }
        public DbSet<CategoryBase> Categories { get; set; }
        public DbSet<Category> OnlyCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>()
                .HasMany<SubCategory>(s => s.SubCategories)
                .WithRequired(s => s.ParentCategory)
                .HasForeignKey(s => s.ParentCategoryId);
            base.OnModelCreating(modelBuilder);
        }

        public static IEnumerable<Category> CategoriesList() {
            StackMoneyDb d = new StackMoneyDb();
            return d.OnlyCategories;
        }
    }
}