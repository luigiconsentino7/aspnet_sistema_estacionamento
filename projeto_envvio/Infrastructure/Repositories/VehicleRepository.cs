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
    public class VehicleRepository(AppDbContext appDbContext) : IVehicleRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly DbSet<Vehicle> _dbSet = appDbContext.Set<Vehicle>();

        public List<Vehicle> GetAll()
        {
            return _appDbContext.Vehicles.ToList();
        }

        public Vehicle GetById(int id)
        {
            return _appDbContext.Vehicles
                .Include(x => x.ParkingLot)
                .SingleOrDefault(x => x.Id == id);
        }

        public Vehicle CreateVehicle(VehicleDTO request)
        {
            _dbSet.Add(new Vehicle(request));
            _appDbContext.SaveChanges();
            return new Vehicle(request);

        }

        public Vehicle UpdateVehicle(int id, VehicleDTO request)
        {
            var vehicle = _dbSet.Find(id);

            vehicle.Model = request.Model;
            vehicle.Color = request.Color;
            vehicle.LicensePlate = request.LicensePlate;
            vehicle.Status = request.Status;

            _appDbContext.Entry(vehicle).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return vehicle;
        }

        public void DesactivateVehicle(int id)
        {
            var vehicle = _dbSet.Find(id);
            if (vehicle != null)
            {
                vehicle.DeactivateVehicle();
                _appDbContext.Entry(vehicle).State = EntityState.Modified;
                _appDbContext.SaveChanges();
            }
        }

        public void DeleteVehicle(int id)
        {
            var vehicle = _dbSet.Find(id);

            _dbSet.Remove(vehicle);
            _appDbContext.SaveChanges();
        }
       

    }
}
