using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bus.DataLayer;
using Bus.DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace BusReservationSystem.Controllers
{
    public class TravelController : Controller
    {
        private readonly ILogger<TravelController> _logger;
        private readonly IConfiguration _configuration;
        private readonly BusDbContext _db;
        
        string apiurl;
        public TravelController(ILogger<TravelController> logger, IConfiguration configuration,BusDbContext db)
        {
            _logger = logger;
            _configuration = configuration;
            _db = db;
            
            apiurl = _configuration.GetValue<string>("WebAPIBaseUrl");

        }
        public async Task<IActionResult> Index(string search="",int PageNo=1)
        {
            
           
            var bus = new List<BusDetails>();
            
            using (HttpClient client = new HttpClient())
            {
                //using (var response = await client.GetAsync("https://localhost:44329/api/character"))
                using (var response = await client.GetAsync(apiurl))
                {
                    var apiresponse = await response.Content.ReadAsStringAsync();
                    bus = JsonConvert.DeserializeObject<List<BusDetails>>(apiresponse);
                }
            }

            ViewBag.Search = search;
            bus = _db.Buses.Where(r => r.BusName.Contains(search)).ToList();


            //Paging
            int noOfRecPerPage = 6;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(bus.Count) / Convert.ToDouble(noOfRecPerPage)));
            int noOfRecToSkip = (PageNo - 1) * noOfRecPerPage;
            ViewBag.NoOfPages = noOfPages;
            ViewBag.PageNo = PageNo;
            bus = bus.Skip(noOfRecToSkip).Take(noOfRecPerPage).ToList();

            

            return View(bus);
        }

        //public async Task<IActionResult>Index(string search)
        //{
        //    ViewData["GetDetails"] = search;
        //    var bus = from x in _db.Buses select x;
        //    if(!String.IsNullOrEmpty(search))
        //    {
        //        bus = bus.Where(x => x.BusName.Contains(search));
        //    }
        //    return View(await bus.AsNoTracking().ToListAsync());

        //}
       
        public async Task<IActionResult> Details(int id)
        {
            var bus = new BusDetails();
            using (var client = new HttpClient())
            {
                //using(var response=await client.GetAsync("https://localhost:44329/api/character/GetById"+id))
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        bus = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                    }
                    else
                    {
                        //var noResponse = response.StatusCode.ToString();
                        //return View(noResponse);
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return View(bus);

        }
        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(BusDetails busDetails)
        {
            var resbus = new BusDetails();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(busDetails), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiurl, content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resbus = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                }

            }
            return RedirectToAction("Index");
            //return View(rescharacter);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var busdata = new BusDetails();
            using (HttpClient client = new HttpClient())
            {

                //using (var response = await client.GetAsync("https://localhost:44330/api/Character"))
                using (var response = await client.GetAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                }
            }
            return View(busdata);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, BusDetails busDetails)
        {
            var busdata = new BusDetails();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(busDetails), Encoding.UTF8,
                    "application/json");
                using (var response = await client.PutAsync($"{apiurl}/{id}", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> DeleteBus(int id)
        {
            var busdata = new BusDetails();
            using (HttpClient client = new HttpClient())
            {

                //using (var response = await client.GetAsync("https://localhost:44330/api/Character"))
                using (var response = await client.DeleteAsync($"{apiurl}/{id}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    busdata = JsonConvert.DeserializeObject<BusDetails>(apiResponse);
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
