using System.Collections.Generic;

namespace Finanse_aspnet_mvc.Models.Categories {
    public class Category : CategoryBase {
        public Category() {
         //   SubCategories = new List<SubCategory>();
        }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}