using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.DAL.Repositories.GarageRepository
{
    interface IGarageRepository
    {
        string CheckInGarage(string vehicleLicensePlate, int vehicleType);
    }
}
