using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; }
        public int ParkingLotId { get; set; }
        public ParkingLotDTO? ParkingLot { get; set; }

        public VehicleDTO() { }

        public VehicleDTO(Vehicle vehicle)
        {
            Id = vehicle.Id;
            Model = vehicle.Model;
            LicensePlate = vehicle.LicensePlate;
            Color = vehicle.Color;
           Status = vehicle.Status;
            ParkingLotId = vehicle.ParkingLotId;
            if (vehicle.ParkingLot != null)
            {
                ParkingLot = new ParkingLotDTO(vehicle.ParkingLot);
            }
        }

        public void DeactivateVehicle(Vehicle vehicle)
        {
            Status = vehicle.Status;
        }
    }
}
