using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.DAL.Entities
{
    public class ParkingLevel
    {
        public int ParkingLevelID { get; set; }

        public int GarageID { get; set; }

        public string ParkingLevelName { get; set; }

        public virtual Garages Garage { get; set; }

        public virtual ICollection<ParkingSpace> ParkingSpaces { get; set; }
    }
}
