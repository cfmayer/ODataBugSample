using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using ODataBugSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataBugSample
{
    public class EdmModelBuilder
    {
        private static IEdmModel _edmModel;

        public static IEdmModel GetEdmModel()
        {
            if (_edmModel == null)
            {
                var builder = new ODataConventionModelBuilder();
                var subjects = builder.EntitySet<Vehicle>("Vehicles");


                _edmModel = builder.GetEdmModel();
            }

            return _edmModel;
        }
    }
}
