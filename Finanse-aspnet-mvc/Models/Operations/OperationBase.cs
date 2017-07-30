using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finanse_aspnet_mvc.Models.Accounts;
using Finanse_aspnet_mvc.Models.Categories;

namespace Finanse_aspnet_mvc.Models.Operations {
    public class OperationBase {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(64)]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [StringLength(1024)]
        [Display(Name = "Więcej informacji")]
        public string MoreInfo { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        [Display(Name = "Wartość")]
        public decimal Cost { get; set; }
        public bool IsExpense { get; set; }
        [ForeignKey("Account")]
        [Display(Name = "Konto")]
        public int AccountId { get; set; }

        public decimal SignedCost => IsExpense ? -Cost : Cost;
        public virtual CategoryBase Category { get; set; }
        public virtual AccountBase Account { get; set; }
        public string TitleOrCategoryName => string.IsNullOrWhiteSpace(Title) ? Category.Name : Title;
    }
}