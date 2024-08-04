using Domain.Account;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using projeto_envvio.Models;
using Service.Interfaces.Repository;
using Service.Interfaces.Service;

namespace projeto_envvio.Controllers
{
    public class UserController(IUserRepository userRepository, IUserService userService, IAuthenticate authenticate) : Controller
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserService _userService = userService;
        private readonly IAuthenticate _autheticate = authenticate;

        [HttpPost("CreateUser")]
        // Roles and claims

        public async Task<ActionResult<UserToken>> CreateUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var emailExist = _autheticate.UserExist(userDTO.Email);

            if (emailExist)
            {
                return BadRequest("Usuário já cadastrado no sistema.");
            }

            var newUsuario = _userService.CreatUser(userDTO);

            if (newUsuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o novo usuário.");
            }

            var token = _autheticate.GenerateToken(newUsuario.Id, newUsuario.Email);
            return new UserToken
            {
                Token = token
            };
        }
    }
}
