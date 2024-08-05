using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; }
        public int ParkingLotId { get; set; }
        public ParkingLot? ParkingLot { get; set; }

        public Vehicle() { }
        public Vehicle(VehicleDTO vehicleDTO)
        {
            Id = vehicleDTO.Id;
            Model = vehicleDTO.Model;
            LicensePlate = vehicleDTO.LicensePlate;
            Color = vehicleDTO.Color;
            Status = vehicleDTO.Status;
            ParkingLotId = vehicleDTO.ParkingLotId;
            if (vehicleDTO.ParkingLot != null)
            {
                ParkingLot = new ParkingLot(vehicleDTO.ParkingLot);
            }
        }

        public void DeactivateVehicle()
        {
            Status = false;
        }

        public void ActivateVehicle()
        {
            Status = true;
        }
    }
}
