using Domain.Entities;
using Domain.Models;

namespace Service.Interfaces.Repository
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User RegisterUser(User request);
        public void UpdateUser(int id, UserDTO request);
        public void DeleteUser(int id);
        public void DesactivateUser(int id);
        public void ActivateUser(int id);
        public User GetByEmail(string email);
    }
}
