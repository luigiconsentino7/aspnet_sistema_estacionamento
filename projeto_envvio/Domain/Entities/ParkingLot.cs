using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? Capacity { get; set; }
        public List<Vehicle>? Vehicles { get; set; } = [];

        public ParkingLot() { }
        public ParkingLot(ParkingLotDTO parkingLotDTO)
        {
            Id = parkingLotDTO.Id;
            Name = parkingLotDTO.Name;
            City = parkingLotDTO.City;
            State = parkingLotDTO.State;
            Country = parkingLotDTO.Country;
            Capacity = parkingLotDTO.Capacity;
            if(parkingLotDTO.Vehicles != null)
            {
                Vehicles = parkingLotDTO.Vehicles.Select(x => new Vehicle(x)).ToList();
            } 
        }
    }
}
