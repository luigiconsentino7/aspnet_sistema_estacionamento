using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Repository;

namespace projeto_envvio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController(IVehicleRepository vehicleRepository, IParkingLotRepository parkingLotRepository) : Controller
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IParkingLotRepository _parkingLotRepository = parkingLotRepository;

        [HttpPost]
        [Route("RegisterVehicle")]
        [ProducesResponseType(201)]
        public IActionResult RegisterVehicle([FromBody] VehicleDTO request)
        {
            var parkingLot = _parkingLotRepository.GetById(request.ParkingLotId);

            if (parkingLot != null)
            {
                var vehicles = parkingLot.Vehicles.Count(x => x.Status == true);

                if (request != null && vehicles <= parkingLot.Capacity - 1)
                {
                    var xpto = _vehicleRepository.CreateVehicle(request);
                    return Created("api/RegisterVehicle", xpto);
                }
                else
                {
                    return BadRequest("Capacidade máxima do estacionamento atingida!");
                }
            }
            else
            {
                return BadRequest("");
            }



        }

        [HttpGet]
        [Route("GetAllVehicles")]
        [ProducesResponseType(typeof(List<VehicleDTO>), 200)]
        public IActionResult GetAll()
        {
            var vehicles = _vehicleRepository.GetAll();

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
            var vehicle = _vehicleRepository.GetById(id);

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
            var vehicle = _vehicleRepository.GetById(id);

            if (vehicle != null)
            {
                _vehicleRepository.UpdateVehicle(id, request);
                return Ok(vehicle);
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
            var vehicle = _vehicleRepository.GetById(id);

            if (vehicle != null)
            {
                _vehicleRepository.DesactivateVehicle(id);
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
            var vehicle = _vehicleRepository.GetById(id);

            if (vehicle != null)
            {
                _vehicleRepository.DeleteVehicle(id);
                return NoContent();
            }
            else
            {
                return NotFound("Veículo não encontrado");
            }
        }
    }
}
