using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
namespace AppServiceLayer.Controllers
{
    [Route("api/BillInfo/")]
    public class BillInfoController : ApiController
    {
        BillInfoImpliment bii=new BillInfoImpliment();  

        [HttpGet]
        [Route("GetAllBill")]
        public HttpResponseMessage GetAllBill()
        {
            var Bill=bii.GetAllBill();
            return Request.CreateResponse(HttpStatusCode.OK,Bill);
        }

        [HttpGet]
        [Route("GetBillById/{Billid}")]
        public HttpResponseMessage GetBillById(int Billid)
        {
            var Bill=bii.GetBillById(Billid);   
            return Request.CreateResponse(HttpStatusCode.OK, Bill); 
        }

        [HttpPost]
        [Route("SaveBill")]
        public HttpResponseMessage PostBill([FromBody]BillInfo bill)
        {
            bii.SaveBill(bill); 
            return Request.CreateResponse(HttpStatusCode.Created); 
        }

        [HttpDelete]
        [Route("DeleteBill/{bill}")]
        public HttpResponseMessage DeleteBill(BillInfo bill)
        {
            bii.DeleteBill(bill);
            return Request.CreateResponse(HttpStatusCode.Gone);
        }

        [HttpPut]
        [Route ("UpdateBill")]
       public HttpResponseMessage PutBill([FromBody]BillInfo bill)
        {
            bii.UpdateBill(bill);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
