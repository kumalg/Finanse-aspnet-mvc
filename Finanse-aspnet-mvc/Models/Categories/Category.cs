using System.Collections.Generic;

namespace Finanse_aspnet_mvc.Models.Categories {
    public class Category : CategoryBase {
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}