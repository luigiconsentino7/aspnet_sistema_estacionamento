using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Repository
{
    public interface IParkingRepository
    {
        public List<ParkingLot> GetAll();
        public ParkingLot GetById(int id);
        public ParkingLot CreateParkingLot(ParkingLotDTO request);
        public void UpdateVehicle(int id, ParkingLotDTO request);
        public void DeleteVehicle(int id);
    }
}
