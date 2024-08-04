using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Repository;

namespace projeto_envvio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingLotController(IParkingLotRepository parkingLotRepository) : Controller
    {
        private readonly IParkingLotRepository _parkingLotRepository = parkingLotRepository;

        [HttpPost]
        [Route("CreateParkingLot")]
        [ProducesResponseType(201)]
        public IActionResult CreateParkingLot([FromBody] ParkingLotDTO request)
        {
            if (request != null)
            {
                _parkingLotRepository.CreateParkingLot(request);
            }

            return Created();
        }

        [HttpGet]
        [Route("GetAllParkingLots")]
        [ProducesResponseType(typeof(List<ParkingLotDTO>), 200)]
        public IActionResult GetAll()
        {
            var parkingLot = _parkingLotRepository.GetAll();

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
            var parkingLot = _parkingLotRepository.GetById(id);

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
            var parkingLot = _parkingLotRepository.GetById(id);

            if (parkingLot != null)
            {
                _parkingLotRepository.UpdateVehicle(id, request);
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
            var parkingLot = _parkingLotRepository.GetById(id);

            if (parkingLot != null)
            {
                _parkingLotRepository.DeleteVehicle(id);
                return NoContent();
            }
            else
            {
                return NotFound("Estacionamento não encontrado");
            }
        }
    }
}
