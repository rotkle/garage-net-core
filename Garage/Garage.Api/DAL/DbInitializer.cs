using Garage.Api.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.DAL
{
    public class DbInitializer
    {
        public static void Initialize(GarageDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Garage.
            if (context.Garages.Any())
            {
                return;   // DB has been seeded
            }

            var garages = new Garages[]
            {
                new Garages {GarageName = "Garage1"},
            };

            foreach (Garages g in garages)
            {
                context.Garages.Add(g);
            }
            context.SaveChanges();

            var parkingLevels = new ParkingLevel[]
            {
                new ParkingLevel{ParkingLevelName="Parking Level 1",GarageID=1},
            };
            foreach (ParkingLevel p in parkingLevels)
            {
                context.ParkingLevels.Add(p);
            }
            context.SaveChanges();

            var vehicleTypes = new VehicleType[]
            {
                new VehicleType{Type="Cars"},
                new VehicleType{Type="Motorbikes"},
            };
            foreach (VehicleType v in vehicleTypes)
            {
                context.VehicleTypes.Add(v);
            }
            context.SaveChanges();

            var parkingSpaces = new ParkingSpace[]
            {
                new ParkingSpace{ParkingSpaceName="Parking Space 1", ParkingLevelId = 1, VehicleTypeID = 1, IsUsed = false},
                new ParkingSpace{ParkingSpaceName="Parking Space 2", ParkingLevelId = 1, VehicleTypeID = 2, IsUsed = false},
            };
            foreach (ParkingSpace p in parkingSpaces)
            {
                context.ParkingSpaces.Add(p);
            }
            context.SaveChanges();
        }
    }
}
