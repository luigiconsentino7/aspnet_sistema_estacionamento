using Domain.Entities;

namespace Domain.Account
{
    public interface IAuthenticate
    {
        public bool Authenticate(string email, string password);
        public bool UserExist(string email);
        public string GenerateToken(int id, string email);

    }
}