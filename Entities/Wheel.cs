using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODataBugSample.Entities
{
    public class Wheel
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Size { get; set; }

        public int Inflation { get; set; }

        public string Condition { get; set; }

        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
