using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Service
{
    public interface IVehicleService
    {
        public List<Vehicle> GetAll();
        public Vehicle GetById(int id);
        public Vehicle CreateVehicle(VehicleDTO request);
        public Vehicle UpdateVehicle(int id, VehicleDTO request);
        public void DesactivateVehicle(int id);
        public void DeleteVehicle(int id);
    }
}
