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
    [Route("VehicleMaster/")]
    public class VehicleMasterController : Controller
    {
        [HttpGet]
        [Route("GetAllVehicle")]
        public async Task<ActionResult> GetAllVehicle()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync("GetAllVehicle");
                if (response.IsSuccessStatusCode)
                {
                    var vehi = await response.Content.ReadAsAsync<VehicleMaster[]>();

                    return View(vehi);
                }
                else
                {
                    return Content("No Data");
                }

            }

        }

        [HttpGet]
        [Route("GetVehicleByModel/{modeNo}")]
        public async Task<ActionResult> GetVehicle(int modeNo)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync($"GetVehicleByModel/{modeNo}");
                if (response.IsSuccessStatusCode)
                {
                    var vehi = await response.Content.ReadAsAsync<VehicleMaster>();

                    return View(vehi);
                }
                else
                {
                    return Content("No Data");
                }

            }
        }

        [HttpPost]
        [Route("SaveVehicle")]
        public async Task<ActionResult> SaveVehicle(VehicleMaster vehicle)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PostAsJsonAsync("SaveVehicle", vehicle);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllVehicle");
                }
                else
                {
                    return View("SaveVehicle");
                }

            }
        }

        [HttpPost]
        [Route("DeleteVehicle/{vehicle}")]
        public async Task<ActionResult> DeleteVehicle(VehicleMaster vehicle)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.DeleteAsync($"DeleteVehicle/{vehicle}");
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllVehicle");
                }
                else
                {
                    return View("DeleteVehicle");
                }

            }

        }
        [HttpPost]
        [Route("UpdateVehicle")]
        public async Task<ActionResult> UpdateVehicle(VehicleMaster vehicle)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PutAsJsonAsync($"UpdateVehicle", vehicle);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllVehicle");
                }
                else
                {
                    return View("UpdateVehicle");
                }

            }
        }
    }
}
