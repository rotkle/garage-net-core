using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.DAL.Entities
{
    public class ParkingSpace
    {
        public int ParkingSpaceID { get; set; }

        public int ParkingLevelId { get; set; }

        public string ParkingSpaceName { get; set; }

        public string VehicleLicensePlate { get; set; }

        public bool IsUsed { get; set; }

        public int VehicleTypeID { get; set; }

        public virtual ParkingLevel ParkingLevel { get; set; }

        public virtual VehicleType VehicleType { get; set; }
    }
}
