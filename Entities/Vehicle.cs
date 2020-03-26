using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataBugSample.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public virtual List<Wheel> Wheels { get; set; }
    }
}
