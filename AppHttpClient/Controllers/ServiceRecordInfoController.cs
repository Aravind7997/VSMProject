using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;

namespace AppHttpClient.Controllers
{
    [Route("ServiceRecordInfo/")]
    public class ServiceRecordInfoController : Controller
    {
        [HttpGet]
        [Route("GetAllServiceRecords")]
        public async Task<ActionResult> GetAllServiceRecords()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync("GetAllServiceRecords");
                if (response.IsSuccessStatusCode)
                {
                    var ServiceRec = await response.Content.ReadAsAsync<ServiceRecordInfo[]>();

                    return View(ServiceRec);
                }
                else
                {
                    return Content("No Data");
                }

            }

        }

        [HttpGet]
        [Route("GetServiceRecordsBy/{servicerefno}")]
        public async Task<ActionResult> GetServiceRecordInfoByServiceRefNo(int servicerefno)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync($"GetServiceRecordsBy/{servicerefno}");
                if (response.IsSuccessStatusCode)
                {
                    var ServiceRec = await response.Content.ReadAsAsync<ServiceRecordInfo>();

                    return View(ServiceRec);
                }
                else
                {
                    return Content("No Data");
                }

            }
        }

        [HttpPost]
        [Route("SaveServiceRecodes")]
        public async Task<ActionResult> SaveServiceRecodes(ServiceRecordInfo serviceRecordInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PostAsJsonAsync("SaveServiceRecodes", serviceRecordInfo);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllServiceRecords");
                }
                else
                {
                    return View("SaveServiceRecodes");
                }

            }
        }

        [HttpPost]
        [Route("DeleteServiceRecodes/{serviceRecordInfo}")]
        public async Task<ActionResult> DeleteServiceRecodes(ServiceRecordInfo serviceRecordInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.DeleteAsync($"DeleteServiceRecodes/{serviceRecordInfo}");
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllServiceRecords");
                }
                else
                {
                    return View("DeleteServiceRecodes");
                }

            }

        }
        [HttpPost]
        [Route("UpdateServiceRecodes")]
        public async Task<ActionResult> UpdateServiceRecodes(ServiceRecordInfo serviceRecordInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PutAsJsonAsync($"UpdateServiceRecodes", serviceRecordInfo);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllServiceRecords");
                }
                else
                {
                    return View("UpdateServiceRecodes");
                }

            }
        }
    }
}