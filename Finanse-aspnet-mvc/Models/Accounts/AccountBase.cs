using System.ComponentModel.DataAnnotations.Schema;

namespace Finanse_aspnet_mvc.Models.Accounts {
    [Table("Accounts")]
    public abstract class AccountBase {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorKey { get; set; }
    }
}