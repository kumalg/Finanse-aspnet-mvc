namespace Finanse_aspnet_mvc.Models.Accounts {
    interface IAccountBase {
        int Id { get; set; }
        string Name { get; set; }
        string ColorKey { get; set; }
    }
}
