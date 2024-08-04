using Domain.Entities;
using Domain.Models;
using Service.Interfaces.Repository;
using Service.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public User CreatUser(UserDTO request)
        {
            return _userRepository.CreateUser(request);
        }

        public void DeleteUser(int id)
        {
           _userRepository.DeleteUser(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User UpdateUser(int id, UserDTO request)
        {
            return _userRepository.UpdateUser(id, request);
        }
    }
}
