using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces.Repository;
using Service.Interfaces.Service;
using System.Security.Cryptography;
using System.Text;

namespace Service.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public User RegisterUser(UserDTO request)
        {
            var user = _mapper.Map<User>(request);
            
            if(request.Password  != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                byte[] passwordSalt = hmac.Key;

                user.UpdatePassword(passwordHash, passwordSalt);
            }
            var newUser = _userRepository.RegisterUser(user);

            return newUser;
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

        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public void UpdateUser(int id, UserDTO request)
        {
            _userRepository.UpdateUser(id, request);
        }

        public void DesactivateUser(int id)
        {
            _userRepository.DesactivateUser(id);
        }

        public void ActivateUser(int id)
        {
            _userRepository.ActivateUser(id);
        }
    }
}
