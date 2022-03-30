using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
namespace AppServiceLayer.Controllers
{
    public class ItemsInfoController : ApiController
    {
       ItemsInfoImpliment iii=new ItemsInfoImpliment();
        [HttpGet]
        [Route("GetAllItems")]
        public HttpResponseMessage GetAllItems()
        {
            var item =iii.GetAllItems() ;
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpGet]
        [Route("GetItemById/{itemId}")]
        public HttpResponseMessage GetItemById(int itemId)
        {
            var items = iii.GetItemById(itemId);
            return Request.CreateResponse(HttpStatusCode.OK, items);
        }

        [HttpPost]
        [Route("SaveItems")]
        public HttpResponseMessage PostItems([FromBody]ItemsInfo itemsInfo)
        {
            iii.SaveItems(itemsInfo);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("DeleteItems/{itemsInfo}")]
        public HttpResponseMessage DeleteItems(ItemsInfo itemsInfo)
        {
          iii.DeleteItems(itemsInfo);
            return Request.CreateResponse(HttpStatusCode.Gone);
        }

        [HttpPut]
        [Route("UpdateItems")]
        public HttpResponseMessage PutItems([FromBody]ItemsInfo itemsInfo)
        {
          iii.UpdateItems(itemsInfo);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

    }
}
