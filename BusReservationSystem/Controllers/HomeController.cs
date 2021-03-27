using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bus.DataLayer;
using BusReservationSystem.Data;
using BusReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
           
            
            return View();
        }
        public IActionResult Privacy()
        {
            //string userName = User.Identity.Name;
            //var result = _db.Registers.Where(e => e.UserName == userName).SingleOrDefault();
            //if (result.Role == "Admin")
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            //else if (result.Role == "Customer")
            //{
            //    return RedirectToAction("Index", "Schedule");
            //}
            return View();

        }
        //public IActionResult Roles()
        //{
        //    string userName = User.Identity.Name;
        //    var result = _db.Registers.Where(e => e.UserName == userName).SingleOrDefault();
        //    if (result.Role == "Admin")
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    else if (result.Role == "Customer")
        //    {
        //        return RedirectToAction("Index", "Schedule");
        //    }
        //    return View();
        //}
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Seats()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";



            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
