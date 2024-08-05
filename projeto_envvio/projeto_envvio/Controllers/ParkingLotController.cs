using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Service;

namespace projeto_envvio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingLotController(IParkingLotService parkingLotService) : Controller
    {
        private readonly IParkingLotService _parkingLotService = parkingLotService;

        [HttpPost]
        [Route("CreateParkingLot")]
        [ProducesResponseType(201)]
        public IActionResult CreateParkingLot([FromBody] ParkingLotDTO request)
        {
            if (request != null)
            {
                _parkingLotService.CreateParkingLot(request);
            }

            return Created();
        }

        [HttpGet]
        [Route("GetAllParkingLots")]
        [ProducesResponseType(typeof(List<ParkingLotDTO>), 200)]
        public IActionResult GetAll()
        {
            var parkingLot = _parkingLotService.GetAll();

            if (parkingLot != null)
            {
                return Ok(parkingLot);
            }
            else
            {
                return NotFound("Nenhum estacionamento encontrado");
            }
        }

        [HttpGet]
        [Route("GetParkingLotById")]
        [ProducesResponseType(typeof(ParkingLotDTO), 200)]
        public IActionResult GetById(int id)
        {
            var parkingLot = _parkingLotService.GetById(id);

            if (parkingLot != null)
            {
                return Ok(parkingLot);
            }
            else
            {
                return NotFound("Nenhum veículo encontrado");
            }
        }

        [HttpPut]
        [Route("UpdateParkingLot")]
        public IActionResult UpdateParkingLot(int id, ParkingLotDTO request)
        {
            var parkingLot = _parkingLotService.GetById(id);

            if (parkingLot != null)
            {
                _parkingLotService.UpdateVehicle(id, request);
                return Ok(parkingLot);
            }
            else
            {
                return NotFound("Estacionamento não encontrado");
            }
        }

        [HttpDelete]
        [Route("DeleteParkingLot")]
        public IActionResult DeleteParkingLot(int id)
        {
            var parkingLot = _parkingLotService.GetById(id);

            if (parkingLot != null)
            {
                _parkingLotService.DeleteVehicle(id);
                return NoContent();
            }
            else
            {
                return NotFound("Estacionamento não encontrado");
            }
        }
    }
}
