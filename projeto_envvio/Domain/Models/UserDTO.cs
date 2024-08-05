using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsSecondAdmin { get; set; } = false;
        [NotMapped]
        public string? Password { get; set; }

        public UserDTO() { }

        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Status = user.Status;
            IsAdmin = user.IsAdmin;
        }

        public void SetAdmin(User user)
        {
            IsAdmin = user.IsAdmin;
        }
        public void SetSecondAdmin(User user)
        {
            IsSecondAdmin = user.IsSecondAdmin;
        }
        public void DeactivateUser(User user)
        {
            Status = user.Status;
        }

        public void ActivateUser(User user)
        {
            Status = user.Status;
        }


    }
}
