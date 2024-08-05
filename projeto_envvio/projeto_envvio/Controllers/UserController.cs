using Domain.Account;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projeto_envvio.Models;
using Service.Interfaces.Repository;
using Service.Interfaces.Service;
using Service.Services;

namespace projeto_envvio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService, IAuthenticate authenticate) : Controller
    {
        private readonly IUserService _userService = userService;
        private readonly IAuthenticate _autheticate = authenticate;

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<UserToken>> RegisterUser([FromBody] UserDTO userDTO)
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

            var newUsuario = _userService.RegisterUser(userDTO);

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

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> LoginUser([FromBody] LoginModel loginModel)
        {
            var userExist = _autheticate.UserExist(loginModel.Email);
            if(!userExist)
            {
                return Unauthorized("Usuário não existe.");
            }

            var result = _autheticate.Authenticate(loginModel.Email, loginModel.Password);

            if(result == false)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            var user = _userService.GetByEmail(loginModel.Email);

            var token = _autheticate.GenerateToken(user.Id, user.Email);

            return new UserToken
            {
                Token = token
            };
        }

        [HttpPut]
        [Authorize]
        [Route("DeactivateUser")]
        public IActionResult DeactivateUser(int id)
        {
            var userId = int.Parse(User.FindFirst("id").Value);

            var user = _userService.GetById(userId);


            if (user != null)
            {
                if (user.IsAdmin)
                {
                    _userService.DesactivateUser(id);
                    return Ok("Usuário desativado");
                }
                else
                {
                    return Unauthorized("Você não tem permissão para desativar usuários.");
                }
            }
            else
            {
                return NotFound("Usuário não encontrado");
            }
        }

        [HttpPut]
        [Authorize]
        [Route("ActivateUser")]
        public IActionResult ActivateUser(int id)
        {
            var userId = int.Parse(User.FindFirst("id").Value);

            var user = _userService.GetById(userId);


            if (user != null)
            {
                if (user.IsAdmin)
                {
                    _userService.ActivateUser(id);
                    return Ok("Usuário ativado");
                }
                else
                {
                    return Unauthorized("Você não tem permissão para ativar usuários.");
                }
            }
            else
            {
                return NotFound("Usuário não encontrado");
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateVehicle(int id, UserDTO request)
        {
            var user = _userService.GetById(id);

            if (user != null)
            {
                _userService.UpdateUser(id, request);
                return Ok();
            }
            else
            {
                return NotFound("Usuário não encontrado");
            }
        }
    }
}
