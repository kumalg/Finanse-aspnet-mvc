using System.Collections.Generic;
using System.Data.Entity;
using Finanse_aspnet_mvc.Models.Accounts;
using Finanse_aspnet_mvc.Models.Categories;
using Finanse_aspnet_mvc.Models.Operations;

namespace Finanse_aspnet_mvc.Models {
    public class StackMoneyDb : DbContext {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationPattern> Patterns { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBase> CategoriesAndSubCategories { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountBase> AccountsAndSubAccounts { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>()
                .HasMany(s => s.SubCategories)
                .WithRequired(s => s.ParentCategory)
                .HasForeignKey(s => s.ParentCategoryId);

            modelBuilder.Entity<Account>()
                .HasMany(s => s.SubAccounts)
                .WithRequired(s => s.ParentAccount)
                .HasForeignKey(s => s.ParentAccountId);

            base.OnModelCreating(modelBuilder);
        }

        public static IEnumerable<Category> OnlyCategoriesList() {
            StackMoneyDb d = new StackMoneyDb();
            return d.Categories;
        }
        public static IEnumerable<CategoryBase> CategoriesList() {
            StackMoneyDb d = new StackMoneyDb();
            return d.CategoriesAndSubCategories;
        }
    }
}