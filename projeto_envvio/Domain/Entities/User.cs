using Domain.Models;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public User() { }

        public User(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Name = userDTO.Name;
            Email = userDTO.Email;
        }

        public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;

        }

    }
}
