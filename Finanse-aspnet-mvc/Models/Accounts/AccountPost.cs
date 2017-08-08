using System.ComponentModel.DataAnnotations;

namespace Finanse_aspnet_mvc.Models.Accounts {
    public class AccountPost : IAccountBase {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorKey { get; set; }
        public int? ParentAccountId { get; set; }
        [Required]
        public string UserId { get; set; }

        public AccountBase GetAccount() {
            AccountBase account;

            if (ParentAccountId.HasValue)
                account = new SubAccount {
                    ParentAccountId = ParentAccountId.Value
                };
            else
                account = new Account();

            account.Id = Id;
            account.Name = Name;
            account.ColorKey = ColorKey;
            account.UserId = UserId;

            return account;
        }
    }
}