using Domain.Entities;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces.Repository;

namespace Infrastructure.Repositories
{
    public class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly DbSet<User> _dbSet = appDbContext.Set<User>();

        public User CreateUser(UserDTO request)
        {
            _dbSet.Add(new User(request));
            _appDbContext.SaveChanges();
            return new User(request);
        }

        public void DeleteUser(int id)
        {
            var user = _dbSet.Find(id);

            _dbSet.Remove(user);
            _appDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _appDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _appDbContext.Users
                .Find(id);
        }

        public User UpdateUser(int id, UserDTO request)
        {
            var user = _dbSet.Find(id);

            user.Name = request.Name;
            user.Email = request.Email;

            _appDbContext.Entry(user).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return user;
        }
    }
}
