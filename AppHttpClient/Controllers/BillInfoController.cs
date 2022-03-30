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
    [Route("BillInfo/")]
    public class BillInfoController : Controller
    {
        // GET: BillInfo
        [HttpGet]
        [Route("GetAllBill")]
        public async Task<ActionResult> GetAllBill()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync("GetAllBill");
                if (response.IsSuccessStatusCode)
                {
                    var bill = await response.Content.ReadAsAsync<BillInfo[]>();

                    return View(bill);
                }
                else
                {
                    return Content("No Data");
                }

            }

        }

        [HttpGet]
        [Route("GetBillById/{Billid}")]
        public async Task<ActionResult> GetBillById(int Billid)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync($"GetBillById/{Billid}");
                if (response.IsSuccessStatusCode)
                {
                    var bill = await response.Content.ReadAsAsync<BillInfo>();

                    return View(bill);
                }
                else
                {
                    return Content("No Data");
                }

            }
        }

        [HttpPost]
        [Route("SaveBill")]
        public async Task<ActionResult> SaveBill(BillInfo bill)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PostAsJsonAsync("SaveBill", bill);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllBill");
                }
                else
                {
                    return View("SaveBill");
                }

            }
        }

        [HttpPost]
        [Route("DeleteBill/{bill}")]
        public async Task<ActionResult> DeleteBill(BillInfo bill)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.DeleteAsync($"DeleteBill/{bill}");
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllBill");
                }
                else
                {
                    return View("DeleteBill");
                }

            }

        }
        [HttpPost]
        [Route("UpdateBill")]
        public async Task<ActionResult> UpdateBill(BillInfo bill)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PutAsJsonAsync($"UpdateBill", bill);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllBill");
                }
                else
                {
                    return View("UpdateBill");
                }

            }
        }
    }
}