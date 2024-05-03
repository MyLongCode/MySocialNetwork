using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.User.Models
{
    public class UserDal
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public string? Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
