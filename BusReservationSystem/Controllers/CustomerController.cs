using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bus.DataLayer;
using Bus.DomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusReservationSystem.Controllers
{
    public class CustomerController : Controller
    {
        BusDbContext _db;
        public CustomerController(BusDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var res = _db.Locations.ToList();
            return View(res);
        }
       
        //[Authorize]
        public IActionResult GetByName(string name)
        {
            
            var res = _db.Trips.Include(e => e.BusDetails).Include(e => e.Route).Where(e => e.Route.FromLocation == name).ToList();
            
            return View(res);
        }

		//[Authorize]
		//public IActionResult ViewSeats(int id)
		//{
		//    ViewBag.UserName = User.Identity.Name;
		//    if(User.Identity.IsAuthenticated)
		//    {
		//        var seat = _db.Trips.Include(e => e.BusDetails).Include(e => e.Route).Where(m => m.RouteID == id).FirstOrDefault();
		//        return View(seat);
		//    }
		//    else
		//    {
		//        return RedirectToAction("Login", "Account");
		//    }
		//}
		[Authorize]
		public IActionResult BookedSeatsData(int id)
		{
			ViewBag.UserName = User.Identity.Name;
			if (User.Identity.IsAuthenticated)
			{
				var userName = User.Identity.Name;
				var booked = _db.BookedSeats.Include(e => e.Trips).Include(e => e.Trips.Route).Include(e => e.Trips.BusDetails).Where(e => e.TripsID == id).FirstOrDefault();


				if (booked == null)
				{
					var books = new BookedSeats
					{
						UserId = userName,
						TripsID = id,
						A1 = 0,
						A2 = 0,
						A3 = 0,
						A4 = 0,
						A5 = 0,
						A6 = 0,
						A7 = 0,
						A8 = 0,
						A9 = 0,
						A10 = 0,
						B1 = 0,
						B2 = 0,
						B3 = 0,
						B4 = 0,
						B5 = 0,
						B6 = 0,
						B7 = 0,
						B8 = 0,
						B9 = 0,
						B10 = 0,
						C1 = 0,
						C2 = 0,
						C3 = 0,
						C4 = 0,
						C5 = 0,
						C6 = 0,
						C7 = 0,
						C8 = 0,
						C9 = 0,
						C10 = 0
					};
					_db.BookedSeats.Add(books);
					_db.SaveChanges();
					return View(books);
				}
				else
				{
					booked.UserId = userName;
					booked.TripsID = id;
				}
				return View(booked);
			}
			else
            {
                return RedirectToAction("Login", "Account");
            }

        }

		public IActionResult Book(BookedSeats booking)
		{
			
			var booked = _db.BookedSeats.Where(e => e.TripsID == booking.TripsID).FirstOrDefault();
			booked.A1 = booking.A1;
			booked.A2 = booking.A2;
			booked.A3 = booking.A3;
			booked.A4 = booking.A4;
			booked.A5 = booking.A5;

			booked.A6 = booking.A6;
			booked.A7 = booking.A7;
			booked.A8 = booking.A8;
			booked.A9 = booking.A9;
			booked.A10 = booking.A10;

			booked.B1 = booking.B1;
			booked.B2 = booking.B2;
			booked.B3 = booking.B3;
			booked.B4 = booking.B4;
			booked.B5 = booking.B5;
			booked.B6 = booking.B6;
			booked.B7 = booking.B7;
			booked.B8 = booking.B8;
			booked.B9 = booking.B9;
			booked.B10 = booking.B10;

			booked.C1 = booking.C1;
			booked.C2 = booking.C2;
			booked.C3 = booking.C3;
			booked.C4 = booking.C4;
			booked.C5 = booking.C5;
			booked.C6 = booking.C6;
			booked.C7 = booking.C7;
			booked.C8 = booking.C8;
			booked.C9 = booking.C9;
			booked.C10 = booking.C10;
			_db.BookedSeats.Update(booked);
			_db.SaveChanges();
			return View(booking);
		}
		public IActionResult OrderDetails()
        {

			
			return View();
        }
		public IActionResult Checkout()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for booking with us";
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Practice()
        {
            return View();
        }
    }
}
