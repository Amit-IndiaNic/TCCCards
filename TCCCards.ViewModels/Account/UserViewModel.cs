namespace TCCCards.ViewModels.Account
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        //public string Password { get; set; }
        public string UserLoginFrom { get; set; }
        // INFO: This will be Distributor ID or Customer ID based on Role
    }
}
