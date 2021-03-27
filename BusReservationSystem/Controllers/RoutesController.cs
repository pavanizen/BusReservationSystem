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
    public class RoutesController : Controller
    {
        private readonly ILogger<RoutesController> _logger;
        private readonly IConfiguration _configuration;
        string apiurl;
        public RoutesController(ILogger<RoutesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            apiurl = _configuration.GetValue<string>("WebAPIBaseUrlRoute");

        }
        public async Task<IActionResult> Index(int PageNo=1)
        {
            var routes = new List<Route>();
            using (HttpClient client = new HttpClient())
            {
                //using (var response = await client.GetAsync("https://localhost:44329/api/character"))
                using (var response = await client.GetAsync(apiurl))
                {
                    var apiresponse = await response.Content.ReadAsStringAsync();
                    routes = JsonConvert.DeserializeObject<List<Route>>(apiresponse);
                }
            }
            //Paging
            int noOfRecPerPage = 6;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(routes.Count) / Convert.ToDouble(noOfRecPerPage)));
            int noOfRecToSkip = (PageNo - 1) * noOfRecPerPage;
            ViewBag.NoOfPages = noOfPages;
            ViewBag.PageNo = PageNo;
            routes = routes.Skip(noOfRecToSkip).Take(noOfRecPerPage).ToList();

            return View(routes);
        }
        public async Task<IActionResult> Details(int id)
        {
            var routes = new Route();
            using (var client = new HttpClient())
            {
                //using(var response=await client.GetAsync("https://localhost:44329/api/character/GetById"+id))
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        routes = JsonConvert.DeserializeObject<Route>(apiResponse);
                    }
                    else
                    {
                        //var noResponse = response.StatusCode.ToString();
                        //return View(noResponse);
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(routes);

        }
        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Route route)
        {
            var resroute = new Route();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(route), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiurl, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resroute = JsonConvert.DeserializeObject<Route>(apiResponse);
                }

            }
            return RedirectToAction("Index");
            //return View(rescharacter);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var busdata = new Route();
            using (HttpClient client = new HttpClient())
            {

                //using (var response = await client.GetAsync("https://localhost:44330/api/Character"))
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<Route>(apiResponse);
                }
            }
            return View(busdata);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, Route route)
        {
            var busdata = new Route();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(route), Encoding.UTF8,
                    "application/json");
                using (var response = await client.PutAsync($"{apiurl}/{id}", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<Route>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRoute(int id)
        {
            var busdata = new Route();
            using (HttpClient client = new HttpClient())
            {

                //using (var response = await client.GetAsync("https://localhost:44330/api/Character"))
                using (var response = await client.DeleteAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<Route>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
