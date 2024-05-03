using Dal.User.Models;

namespace Dal.User.Interfaces
{
    public interface IUserRepository
    {
        public UserDal[] GetAllUsers();
        public int CreateUser(UserDal user);
        public void UpdateUser(UserDal user);
        public void EditUserStatus(int userId, string status);
        public void DeleteUser(int userId);

    }
}
