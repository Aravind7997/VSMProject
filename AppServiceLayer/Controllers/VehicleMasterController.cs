using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
namespace AppServiceLayer.Controllers
{
    [Route("api/VehicleMaster")]
    public class VehicleMasterController : ApiController
    {
        VehicleMasterImpliment vmi=new VehicleMasterImpliment();    
        [HttpGet]
        [Route("GetAllVehicle")]
        public HttpResponseMessage GetAllVehicle()
        {
            var vehicle = vmi.GetAllVehicle();
            return Request.CreateResponse(HttpStatusCode.OK, vehicle);  
        }
        [HttpGet]
        [Route("GetVehicleByModel/{modeNo}")]
        public HttpResponseMessage GetVehicle(int modeNo)
        {
        var vehicle=vmi.GetVehicle(modeNo); 
        return Request.CreateResponse(HttpStatusCode.OK, vehicle);
        }

        [HttpPost]
        [Route("SaveVehicle")]
        public HttpResponseMessage PostVehicle([FromBody]VehicleMaster vehicle)
        {
            vmi.SaveVehicle(vehicle);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("DeleteVehicle/{vehicle}")]
        public HttpResponseMessage DeleteVehicle(VehicleMaster vehicle)
        {
            vmi.DeleteVehicle(vehicle);
            return Request.CreateResponse(HttpStatusCode.Gone); 
        }

        [HttpPut]
        [Route("UpdateVehicle")]
        public HttpResponseMessage PutVehicle([FromBody]VehicleMaster vehicle)
        {
        vmi.UpdateVehicle(vehicle); 
        return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
