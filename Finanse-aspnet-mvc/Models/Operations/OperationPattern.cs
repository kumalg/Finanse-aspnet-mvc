using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finanse_aspnet_mvc.Models.Categories;

namespace Finanse_aspnet_mvc.Models.Operations {
    [Table("Patterns")]
    public class OperationPattern {
        public int Id { get; set; }
        [StringLength(64)]
        public string Title { get; set; }
        [StringLength(1024)]
        public string MoreInfo { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public decimal Cost { get; set; }
        public bool IsExpense { get; set; }
        public string MoneyAccountId { get; set; }

        public decimal SignedCost => IsExpense ? -Cost : Cost;
        public virtual CategoryBase Category { get; set; }
        public string TitleOrCategoryName => string.IsNullOrWhiteSpace(Title) ? Category.Name : Title;
    }
}