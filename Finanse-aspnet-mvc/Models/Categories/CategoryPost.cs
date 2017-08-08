using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finanse_aspnet_mvc.Models.Categories {
    public class CategoryPost : ICategoryBase {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorKey { get; set; }
        public string IconKey { get; set; }
        public bool VisibleInIncomes { get; set; }
        public bool VisibleInExpenses { get; set; }
        public bool CantDelete { get; set; }
        public int? ParentCategoryId { get; set; }

        public CategoryBase GetCategory() {
            CategoryBase category;

            if (ParentCategoryId.HasValue && ParentCategoryId.Value != -1)
                category = new SubCategory {
                    ParentCategoryId = ParentCategoryId.Value
                };
            else
                category = new Category();

            category.Id = Id;
            category.Name = Name;
            category.ColorKey = ColorKey;
            category.IconKey = IconKey;
            category.VisibleInIncomes = VisibleInIncomes;
            category.VisibleInExpenses = VisibleInExpenses;
            category.CantDelete = CantDelete;

            return category;
        }
    }
}
