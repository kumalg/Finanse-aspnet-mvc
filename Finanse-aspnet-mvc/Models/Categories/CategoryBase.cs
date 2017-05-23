using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanse_aspnet_mvc.Models.Categories {
    [Table("Categories")]
    public abstract class CategoryBase {
        public int Id { get; set; }

        [StringLength(32)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string ColorKey { get; set; }
        public string IconKey { get; set; }
        public bool VisibleInIncomes { get; set; }
        public bool VisibleInExpenses { get; set; }
        public bool CantDelete { get; set; }
    }
}