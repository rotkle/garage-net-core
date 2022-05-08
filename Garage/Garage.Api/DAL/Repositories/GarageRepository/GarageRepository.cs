using Garage.Api.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.DAL.Repositories.GarageRepository
{
    public class GarageRepository : IGarageRepository
    {
        private readonly IGenericRepository<Garages> garageRepo;
        private readonly IGenericRepository<ParkingLevel> parkingLevelRepo;
        private readonly IGenericRepository<ParkingSpace> parkingSpaceRepo;
        private readonly IGenericRepository<VehicleType> vehicleTypeRepo;

        public GarageRepository(IGenericRepository<Garages> garageRepo,
                                IGenericRepository<ParkingLevel> parkingLevelRepo,
                                IGenericRepository<ParkingSpace> parkingSpaceRepo,
                                IGenericRepository<VehicleType> vehicleTypeRepo)
        {
            this.garageRepo = garageRepo;
            this.parkingLevelRepo = parkingLevelRepo;
            this.parkingSpaceRepo = parkingSpaceRepo;
            this.vehicleTypeRepo = vehicleTypeRepo;
        }

        public string CheckInGarage(string vehicleLicensePlate, int vehicleType)
        {
            throw new NotImplementedException();
        }
    }
}
