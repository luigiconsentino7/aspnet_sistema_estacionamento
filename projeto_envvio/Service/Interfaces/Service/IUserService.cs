using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Service
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User CreatUser(UserDTO request);
        public User UpdateUser(int id, UserDTO request);
        public void DeleteUser(int id);
    }
}
