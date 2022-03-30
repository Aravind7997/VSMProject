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
    [Route("ServiceRepInfo/")]
    public class ServiceRepInfoController : Controller
    {
        // GET: BillInfo
        [HttpGet]
        [Route("GetAllServiceRep")]
        public async Task<ActionResult> GetAllServiceRep()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync("GetAllServiceRep");
                if (response.IsSuccessStatusCode)
                {
                    var ServiceRep = await response.Content.ReadAsAsync<ServiceRepInfo[]>();

                    return View(ServiceRep);
                }
                else
                {
                    return Content("No Data");
                }

            }

        }

        [HttpGet]
        [Route("GetServiceRepByServiceRepId/{ServiceRepid}")]
        public async Task<ActionResult> GetServiceRepByServiceRepId(int ServiceRepid)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync($"GetServiceRepByServiceRepId/{ServiceRepid}");
                if (response.IsSuccessStatusCode)
                {
                    var ServiceRep = await response.Content.ReadAsAsync<ServiceRepInfo>();

                    return View(ServiceRep);
                }
                else
                {
                    return Content("No Data");
                }

            }
        }

        [HttpPost]
        [Route("SaveServiceRep")]
        public async Task<ActionResult> SaveServiceRep(ServiceRepInfo serviceRepInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PostAsJsonAsync("SaveServiceRep", serviceRepInfo);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllServiceRep");
                }
                else
                {
                    return View("SaveServiceRep");
                }

            }
        }

        [HttpPost]
        [Route("DeleteServiceRep/{serviceRepInfo}")]
        public async Task<ActionResult> DeleteServiceRep(ServiceRepInfo serviceRepInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.DeleteAsync($"DeleteServiceRep/{serviceRepInfo}");
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllServiceRep");
                }
                else
                {
                    return View("DeleteServiceRep");
                }

            }

        }
        [HttpPost]
        [Route("UpdateServiceRep")]
        public async Task<ActionResult> UpdateServiceRep(ServiceRepInfo serviceRepInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PutAsJsonAsync($"UpdateServiceRep", serviceRepInfo);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllServiceRep");
                }
                else
                {
                    return View("UpdateServiceRep");
                }

            }
        }
    }
}