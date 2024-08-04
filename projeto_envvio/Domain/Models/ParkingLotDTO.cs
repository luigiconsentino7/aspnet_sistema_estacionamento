using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ParkingLotDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? Capacity { get; set; }
        public List<VehicleDTO>? Vehicles { get; set; } = [];

        public ParkingLotDTO() { }
        public ParkingLotDTO(ParkingLot parkingLot)
        {
            Id = parkingLot.Id;
            Name = parkingLot.Name;
            City = parkingLot.City;
            State = parkingLot.State;
            Country = parkingLot.Country;
            Capacity = parkingLot.Capacity;
            if(parkingLot.Vehicles != null)
            {
                Vehicles = parkingLot.Vehicles.Select(x => new VehicleDTO(x)).ToList();
            } 
        }
    }
}
