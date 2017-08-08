namespace Finanse_aspnet_mvc.Models.Accounts {
    public class SubAccount : AccountBase, ISubAccount {
        public int ParentAccountId { get; set; }
        public virtual Account ParentAccount { get; set; }
    }
}