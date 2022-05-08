using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.DAL.Entities
{
    public class VehicleType
    {
        public int VehicleTypeID { get; set; }

        public string Type { get; set; }

        public virtual ICollection<ParkingSpace> ParkingSpaces { get; set; }
    }
}
