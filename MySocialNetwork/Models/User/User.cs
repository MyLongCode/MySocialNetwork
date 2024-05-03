namespace MySocialNetworkApi.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public string? Avatar { get; set; }
    }
}
