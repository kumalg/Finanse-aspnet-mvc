namespace Finanse_aspnet_mvc.Models.Categories {
    public class SubCategory : CategoryBase, ISubCategory {
        public int ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public Category AsCategory() {
            return new Category {
                Id = Id,
                Name = Name,
                ColorKey = ColorKey,
                IconKey = IconKey,
                VisibleInExpenses = VisibleInExpenses,
                VisibleInIncomes = VisibleInIncomes,
                CantDelete = CantDelete
            };
        }
    }
}