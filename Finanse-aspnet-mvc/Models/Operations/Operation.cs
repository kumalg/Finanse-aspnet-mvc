using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanse_aspnet_mvc.Models.Operations {
    [Table("Operations")]
    public class Operation : OperationBase {
        [Display(Name = "Data")]
        public string Date { get; set; }
        [Display(Name = "Widoczna w statystykach")]
        public bool VisibleInStatistics { get; set; } = true;
    }
}