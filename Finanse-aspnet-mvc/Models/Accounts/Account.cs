using System.Collections.Generic;

namespace Finanse_aspnet_mvc.Models.Accounts {
    public class Account : AccountBase {
        public virtual ICollection<SubAccount> SubAccounts { get; set; } = new List<SubAccount>();
    }
}