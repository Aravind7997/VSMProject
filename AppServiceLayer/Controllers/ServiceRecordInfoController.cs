using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
namespace AppServiceLayer.Controllers
{ 

[Route("api/ServiceRecordInfo/")]
public class ServiceRecordInfoController : ApiController
{
    ServiceRecordInfoImpliment srii = new ServiceRecordInfoImpliment();

    [HttpGet]
    [Route("GetAllServiceRecords")]
    public HttpResponseMessage GetAllServiceRecords()
    {
        var records = srii.GetAllServiceRecords();
        return Request.CreateResponse(HttpStatusCode.OK, records);
    }

    [HttpGet]
    [Route("GetServiceRecordsBy/{servicerefno}")]
    public HttpResponseMessage GetServiceRecordInfoByServiceRefNo(int servicerefno)
    {
        var serRefNo=srii.GetServiceRecordInfoByServiceRefNo(servicerefno);
        return Request.CreateResponse(HttpStatusCode.OK, serRefNo);

    }

    [HttpPost]
    [Route("SaveServiceRecodes")]
    public HttpResponseMessage PostServiceRecodes([FromBody]ServiceRecordInfo serviceRecordInfo)
    {
        srii.SaveServiceRecodes(serviceRecordInfo);
        return Request.CreateResponse(HttpStatusCode.Created);   
    }

    [HttpDelete]
    [Route("DeleteServiceRecodes/{serviceRecordInfo}")]

    public HttpResponseMessage DeleteServiceRecodes(ServiceRecordInfo serviceRecordInfo)
    {
        srii.DeleteServiceRecodes(serviceRecordInfo);   
        return Request.CreateResponse(HttpStatusCode.Gone); 
    }

    [HttpPut]
    [Route("UpdateServiceRecodes")]
    public HttpResponseMessage PutServiceRecodes([FromBody]ServiceRecordInfo serviceRecordInfo)
    {
        srii.UpdateServiceRecodes(serviceRecordInfo);
        return Request.CreateResponse(HttpStatusCode.Accepted);
    }
}
}
