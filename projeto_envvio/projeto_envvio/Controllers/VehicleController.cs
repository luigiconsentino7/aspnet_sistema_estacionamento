using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Service;

namespace projeto_envvio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController(IVehicleService vehicleService, IParkingLotService parkingLotService, IUserService userService) : Controller
    {
        private readonly IVehicleService _vehicleService = vehicleService;
        private readonly IParkingLotService _parkingLotService = parkingLotService;
        private readonly IUserService _userService = userService;

        [HttpPost]
        [Route("RegisterVehicle")]
        [ProducesResponseType(201)]
        [Authorize]
        public IActionResult RegisterVehicle([FromBody] VehicleDTO request)
        {
            var userId = int.Parse(User.FindFirst("id").Value);

            var user = _userService.GetById(userId);

            if (user.IsSecondAdmin)
            {
                var parkingLot = _parkingLotService.GetById(request.ParkingLotId);

                var vehicles = parkingLot.Vehicles.Count(x => x.Status == true);

                if (request != null && vehicles <= parkingLot.Capacity - 1)
                {
                    var xpto = _vehicleService.CreateVehicle(request);
                    return Created("api/RegisterVehicle", xpto);
                }
                else
                {
                    return BadRequest("Capacidade máxima do estacionamento atingida!");
                }
            }
            else
            {
                return Unauthorized("Você não tem permissão para cadastrar veículos.");
            }

            

        }

        [HttpGet]
        [Route("GetAllVehicles")]
        [ProducesResponseType(typeof(List<VehicleDTO>), 200)]
        public IActionResult GetAll()
        {
            var vehicles = _vehicleService.GetAll();

            if (vehicles != null)
            {
                return Ok(vehicles);
            }
            else
            {
                return NotFound("Nenhum veículo encontrado");
            }
        }

        [HttpGet]
        [Route("GetVehicleById")]
        [ProducesResponseType(typeof(VehicleDTO), 200)]
        public IActionResult GetById(int id)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            else
            {
                return NotFound("Nenhum veículo encontrado");
            }
        }

        [HttpPut]
        [Route("UpdateVehicle")]
        public IActionResult UpdateVehicle(int id, VehicleDTO request)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle != null)
            {
                _vehicleService.UpdateVehicle(id, request);
                return Ok(vehicle);
            }
            else
            {
                return NotFound("Veículo não encontrado");
            }
        }

        [HttpPut]
        [Route("ActivateVehicle")]
        public IActionResult ActivateVehicle(int id)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle != null)
            {
                _vehicleService.ActivateVehicle(id);
                return Ok("Veículo ativado");
            }
            else
            {
                return NotFound("Veículo não encontrado");
            }
        }

        [HttpPut]
        [Route("DeactivateVehicle")]
        public IActionResult DeactivateVehicle(int id)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle != null)
            {
                _vehicleService.DesactivateVehicle(id);
                return Ok("Veículo desativado");
            }
            else
            {
                return NotFound("Veículo não encontrado");
            }
        }

        [HttpDelete]
        [Route("DeleteVehicle")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = _vehicleService.GetById(id);

            if (vehicle != null)
            {
                _vehicleService.DeleteVehicle(id);
                return NoContent();
            }
            else
            {
                return NotFound("Veículo não encontrado");
            }
        }
    }
}
