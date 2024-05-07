using Dal.EF;
using Dal.User.Interfaces;
using Dal.User.Models;

namespace Dal.User
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext db;
        public UserRepository(ApplicationDbContext context) => db = context;
        public int CreateUser(UserDal user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void EditUserStatus(int userId, string status)
        {
            throw new NotImplementedException();
        }

        public UserDal[] GetAllUsers()
        {
            return db.Users.ToArray();
        }

        public UserDal GetUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUser(UserDal user)
        {
            throw new NotImplementedException();
        }
    }
}
