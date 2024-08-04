using Domain.Entities;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ParkingLotRepository(AppDbContext appDbContext) : IParkingLotRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly DbSet<ParkingLot> _dbSet = appDbContext.Set<ParkingLot>();

        public List<ParkingLot> GetAll()
        {
            return _appDbContext.ParkingLots.ToList();
        }

        public ParkingLot GetById(int id)
        {
            return _appDbContext.ParkingLots
                .Include(x => x.Vehicles)
                .Where(x => x.Id.Equals(id))
                .FirstOrDefault();

        }

        public ParkingLot CreateParkingLot(ParkingLotDTO request)
        {
            _dbSet.Add(new ParkingLot(request));
            _appDbContext.SaveChanges();
            return new ParkingLot(request);

        }

        public void UpdateVehicle(int id, ParkingLotDTO request)
        {
            var parkingLot = _dbSet.Find(id);

            if (parkingLot != null)
            {
                parkingLot.Name = request.Name;
                parkingLot.City = request.City;
                parkingLot.State = request.State;
                parkingLot.Country = request.Country;
                parkingLot.Capacity = request.Capacity;

                _appDbContext.Entry(parkingLot).State = EntityState.Modified;
                _appDbContext.SaveChanges();
            }
            
        }

        public void DeleteVehicle(int id)
        {
            var parkingLot = _dbSet.Find(id);

            if (parkingLot != null)
            {
                _dbSet.Remove(parkingLot);
                _appDbContext.SaveChanges();
            }
        }
    }
}
