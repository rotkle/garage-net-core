using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.DAL.Entities
{
    public class Garages
    {
        public int GarageID { get; set; }

        public string GarageName { get; set; }

        public virtual ICollection<ParkingLevel> ParkingLevels { get; set; }
    }
}
