using Domain.Entities;
using Domain.Models;

namespace Service.Interfaces.Repository
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User CreateUser(UserDTO request);
        public User UpdateUser(int id, UserDTO request);
        public void DeleteUser(int id);
    }
}
