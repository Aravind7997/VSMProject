using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;

namespace AppServiceLayer.Controllers
{
    [Route("api/CustomerMaster")]
    public class CustomerMasterController : ApiController
    {
        CustomerMasterImpliment cmi=new CustomerMasterImpliment();
        [HttpGet]
        [Route("GetAllCustomer")]
        public HttpResponseMessage GetAllCustomer()
        {
            var customers = cmi.GetAllCustomer();
            return Request.CreateResponse(HttpStatusCode.OK, customers);    
        }
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public HttpResponseMessage GetCustomerById(int id)
        {
            var customer = cmi.GetCustomerById(id); 
            return Request.CreateResponse(HttpStatusCode.OK, customer); 

        }

        [HttpPost]
        [Route("SaveCustomer")]
        public HttpResponseMessage PostCustomer([FromBody]CustomerMaster customer)
        {
            cmi.SaveCustomer(customer);
            return Request.CreateResponse(HttpStatusCode.Created); 
        }

        [HttpDelete]
        [Route("DeleteCustomer/{customer}")]
        public HttpResponseMessage DeleteCustomer(CustomerMaster customer)
        {
        cmi.DeleteCustomer(customer);
        return Request.CreateResponse(HttpStatusCode.Gone);

        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public HttpResponseMessage PutCustomer([FromBody]CustomerMaster customer)
        {
            cmi.UpdteCustomer(customer);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
