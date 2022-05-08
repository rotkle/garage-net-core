using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.Services.Garage
{
    interface IGarageService
    {
        string CheckInGarage(string vehicleLicensePlate, int vehicleType);
    }
}
