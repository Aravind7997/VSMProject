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
    [Route("ItemsInfo/")]
    public class ItemsInfoController : Controller
    {
        // GET: BillInfo
        [HttpGet]
        [Route("GetAllItems")]
        public async Task<ActionResult> GetAllItems()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync("GetAllItems");
                if (response.IsSuccessStatusCode)
                {
                    var item = await response.Content.ReadAsAsync<ItemsInfo[]>();

                    return View(item);
                }
                else
                {
                    return Content("No Data");
                }

            }

        }

        [HttpGet]
        [Route("GetItemById/{itemId}")]
        public async Task<ActionResult> GetItemById(int itemId)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.GetAsync($"GetItemById/{itemId}");
                if (response.IsSuccessStatusCode)
                {
                    var item = await response.Content.ReadAsAsync<ItemsInfo>();

                    return View(item);
                }
                else
                {
                    return Content("No Data");
                }

            }
        }

        [HttpPost]
        [Route("SaveItems")]
        public async Task<ActionResult> SaveItems(ItemsInfo itemsInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PostAsJsonAsync("SaveItems", itemsInfo);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllItems");
                }
                else
                {
                    return View("SaveItems");
                }

            }
        }

        [HttpPost]
        [Route("DeleteItems/{itemsInfo}")]
        public async Task<ActionResult> DeleteItems(ItemsInfo itemsInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.DeleteAsync($"DeleteItems/{itemsInfo}");
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllItems");
                }
                else
                {
                    return View("DeleteItems");
                }

            }

        }
        [HttpPost]
        [Route("UpdateItems")]
        public async Task<ActionResult> UpdateItems(ItemsInfo itemsInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62937/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //Get Method
                HttpResponseMessage response = await client.PutAsJsonAsync($"UpdateItems", itemsInfo);
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("GetAllItems");
                }
                else
                {
                    return View("UpdateItems");
                }

            }
        }
    }
}