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
        [NotMapped]
        public string Password { get; set; }

        public UserDTO() { }

        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        
        }


    }
}
