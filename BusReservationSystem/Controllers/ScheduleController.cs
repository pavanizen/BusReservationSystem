using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bus.DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BusReservationSystem.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IConfiguration _configuration;
        string apiurl;
        public ScheduleController(ILogger<ScheduleController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            apiurl = _configuration.GetValue<string>("WebAPIBaseUrlSchedule");

        }
        public async Task<IActionResult> Index(int PageNo=1)
        {
            var trips = new List<Trip>();
            using (HttpClient client = new HttpClient())
            {
                //using (var response = await client.GetAsync("https://localhost:44329/api/character"))
                using (var response = await client.GetAsync(apiurl))
                {
                    var apiresponse = await response.Content.ReadAsStringAsync();
                    trips = JsonConvert.DeserializeObject<List<Trip>>(apiresponse);
                }
            }
            //Paging
            int noOfRecPerPage = 6;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(trips.Count) / Convert.ToDouble(noOfRecPerPage)));
            int noOfRecToSkip = (PageNo - 1) * noOfRecPerPage;
            ViewBag.NoOfPages = noOfPages;
            ViewBag.PageNo = PageNo;
            trips = trips.Skip(noOfRecToSkip).Take(noOfRecPerPage).ToList();

            return View(trips);
        }
        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Trip trips)
        {
            var resroute = new Trip();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(trips), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiurl, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resroute = JsonConvert.DeserializeObject<Trip>(apiResponse);
                }

            }
            return RedirectToAction("Index");
            //return View(rescharacter);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var busdata = new Trip();
            using (HttpClient client = new HttpClient())
            {

                //using (var response = await client.GetAsync("https://localhost:44330/api/Character"))
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<Trip>(apiResponse);
                }
            }
            return View(busdata);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, Trip trip)
        {
            var busdata = new Trip();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(trip), Encoding.UTF8,
                    "application/json");
                using (var response = await client.PutAsync($"{apiurl}/{id}", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<Trip>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DeleteTrip(int id)
        {

            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri("https://localhost:44391/api/Trip");

            //    //HTTP DELETE
            //    var deleteTask = client.DeleteAsync("Trip/" + id.ToString());
            //    deleteTask.Wait();

            //    var result = deleteTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {

            //        return RedirectToAction("Index");
            //    }
            //    return RedirectToAction("Index");
            //}



            var busdata = new Trip();
            using (HttpClient client = new HttpClient())
            {

                //using (var response = await client.GetAsync("https://localhost:44330/api/Character"))
                using (var response = await client.DeleteAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<Trip>(apiResponse);
                }
            }
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Details(int id)
        {
            var trips = new Trip();
            using (var client = new HttpClient())
            {
                //using(var response=await client.GetAsync("https://localhost:44329/api/character/GetById"+id))
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        trips = JsonConvert.DeserializeObject<Trip>(apiResponse);
                    }
                    else
                    {
                        //var noResponse = response.StatusCode.ToString();
                        //return View(noResponse);
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(trips);

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
