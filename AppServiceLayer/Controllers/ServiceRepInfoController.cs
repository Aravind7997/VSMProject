using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
namespace AppServiceLayer.Controllers
{
    [Route("api/ServiceRep")]
    public class ServiceRepInfoController : ApiController
    {
        ServiceRepInfoImpliment sri = new ServiceRepInfoImpliment();

        [HttpGet]
        [Route("GetAllServiceRep")]
        public HttpResponseMessage GetAllServiceRep()
        {
            var serviceRep = sri.GetAllServiceRep();
            return Request.CreateResponse(HttpStatusCode.OK, serviceRep);
        }

        [HttpGet]
        [Route("GetServiceRepByServiceRepId/{ServiceRepid}")]
        public HttpResponseMessage GetServiceRepByServiceRepId(int ServiceRepid)
        {
            var serviceRep = sri.GetServiceRepByServiceRepId(ServiceRepid);
            return Request.CreateResponse(HttpStatusCode.OK, serviceRep);
        }

        [HttpPost]
        [Route("SaveServiceRep")]
        public HttpResponseMessage PostServiceRep([FromBody]ServiceRepInfo serviceRepInfo)
        {
            sri.SaveServiceRep(serviceRepInfo);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("DeleteServiceRep/{serviceRepInfo}")]
        public HttpResponseMessage DeleteServiceRep(ServiceRepInfo serviceRepInfo)
        {
            sri.DeleteServiceRep(serviceRepInfo);
            return Request.CreateResponse(HttpStatusCode.Gone);
        }

        [HttpPut]
        [Route("UpdateServiceRep")]
        public HttpResponseMessage PutServiceRep([FromBody]ServiceRepInfo serviceRepInfo)
        {
            sri.UpdateServiceRep(serviceRepInfo);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
