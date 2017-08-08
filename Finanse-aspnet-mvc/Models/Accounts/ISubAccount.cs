namespace Finanse_aspnet_mvc.Models.Accounts {
    interface ISubAccount: IAccountBase {
        int ParentAccountId { get; set; }
    }
}
