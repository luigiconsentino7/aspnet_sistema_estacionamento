using Domain.Entities;
using Domain.Models;

namespace Service.Interfaces.Service
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User RegisterUser(UserDTO request);
        public void UpdateUser(int id, UserDTO request);
        public void DeleteUser(int id);
        public void DesactivateUser(int id);
        public void ActivateUser(int id);
        public User GetByEmail(string email);
    }
}
