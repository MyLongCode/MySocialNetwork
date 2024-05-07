namespace MySocialNetworkApi.Models.User.Requests
{
    public class CreateUserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
