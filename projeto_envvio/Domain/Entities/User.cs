using Domain.Models;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSecondAdmin { get; set; }
        public bool? Status { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public User() { }

        public User(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Name = userDTO.Name;
            Email = userDTO.Email;
            Status = userDTO.Status;
            IsAdmin = userDTO.IsAdmin;
            IsSecondAdmin = userDTO.IsSecondAdmin;
        }

        public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public void SetAdmin(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }

        public void SetSecondAdmin(bool isSecondAdmin)
        {
            IsSecondAdmin = isSecondAdmin;
        }

        public void DeactivateUser()
        {
            Status = false;
        }

        public void ActivateUser()
        {
            Status = true;
        }

    }
}
