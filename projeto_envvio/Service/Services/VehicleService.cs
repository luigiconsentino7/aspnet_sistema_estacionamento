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
    public class VehicleService(IVehicleRepository vehicleRepository) : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        public List<Vehicle> GetAll()
        {
            return _vehicleRepository.GetAll();
        }
        public Vehicle GetById(int id)
        {
            return _vehicleRepository.GetById(id);
        }
        public Vehicle CreateVehicle (VehicleDTO request)
        {
            return _vehicleRepository.CreateVehicle(request);
        }

        public Vehicle UpdateVehicle(int id, VehicleDTO request)
        {
            return _vehicleRepository.UpdateVehicle(id, request);
        }

        public void DesactivateVehicle(int id)
        {
            _vehicleRepository.DesactivateVehicle(id);
        }

        public void ActivateVehicle(int id)
        {
            _vehicleRepository.DesactivateVehicle(id);
        }

        public void DeleteVehicle(int id)
        {
            _vehicleRepository.DeleteVehicle(id);
        }
    }
}
