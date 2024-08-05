﻿using System.ComponentModel.DataAnnotations;

namespace projeto_envvio.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
