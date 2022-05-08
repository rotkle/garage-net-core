using Garage.Api.DAL.Entities;
using Garage.Api.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.Services.Garage
{
    public class GarageService : IGarageService
    {
        private readonly IGenericRepository<VehicleType> vehicleTypeRepo;

        public GarageService(IGenericRepository<VehicleType> vehicleTypeRepo)
        {
            this.vehicleTypeRepo = vehicleTypeRepo;
        }

        public string CheckInGarage(string vehicleLicensePlate, int vehicleType)
        {
            if (string.IsNullOrWhiteSpace(vehicleLicensePlate))
            {
                throw new ArgumentException("Invalid license plate!", nameof(vehicleLicensePlate));
            }

            if (this.vehicleTypeRepo.GetById(vehicleType) == null)
            {
                throw new ArgumentException("Invalid vehicle type!", nameof(vehicleType));
            }

            throw new NotImplementedException();
        }
    }
}
