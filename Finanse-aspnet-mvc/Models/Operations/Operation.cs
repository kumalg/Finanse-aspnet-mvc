using System.ComponentModel.DataAnnotations.Schema;

namespace Finanse_aspnet_mvc.Models.Operations {
  //  [Table("Operations")]
    public class Operation : OperationPattern {
        public string Date { get; set; }
        public bool VisibleInStatistics { get; set; } = true;
    }
}