using Domain.Entities;
using Domain.Models;
using Service.Interfaces.Repository;
using Service.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ParkingLotService(IParkingLotRepository parkingLotRepository) : IParkingLotService
    {
        private readonly IParkingLotRepository _parkingLotRepository = parkingLotRepository;

        public List<ParkingLot> GetAll()
        {
            return _parkingLotRepository.GetAll();
        }

        public ParkingLot GetById(int id)
        {
            return _parkingLotRepository.GetById(id);
        }
        public ParkingLot CreateParkingLot(ParkingLotDTO request)
        {
            return _parkingLotRepository.CreateParkingLot(request);
        }
        public void UpdateVehicle(int id, ParkingLotDTO request)
        {
            _parkingLotRepository.UpdateVehicle(id, request);
        }
        public void DeleteVehicle(int id)
        {
            _parkingLotRepository.DeleteVehicle(id);
        }
    }
}
