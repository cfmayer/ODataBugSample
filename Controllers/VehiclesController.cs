using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataBugSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataBugSample.Controllers
{
    public class VehiclesController : ODataController
    {
        private readonly VehicleDbContext dbContext;

        public VehiclesController(VehicleDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbContext.Database.EnsureCreated();
        }

        [EnableQuery]
        public IActionResult Get()
        {
                var result = dbContext.Vehicles;

            return Ok(result);
        }
    }
}
