using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bus.DataLayer;
using Bus.DomainModels.Models;
using Bus.RepositoryContract;

namespace Bus.RepositoryLayer
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly BusDbContext _db;

        public ScheduleRepository(BusDbContext db)
        {
            _db = db;
        }

        public List<Trip> GetAllTripDetails()
        {
            var tripData = _db.Trips.ToList();
            return tripData;
        }

        public Trip GetTripById(int id)
        {
            var singleData = _db.Trips.FirstOrDefault(b => b.TripID == id);
            return singleData;
        }

        public Trip AddTrip(Trip trip)
        {
            _db.Trips.Add(trip);
            _db.SaveChanges();
            return trip;
        }

        public Trip EditTrip(int id, Trip trip)
        {
            var res = _db.Trips.FirstOrDefault(e => e.TripID == id);
            res.JourneyDate = trip.JourneyDate;
            res.AvailableSeats = trip.AvailableSeats;
            res.RouteID = trip.RouteID;
            res.BusID = trip.BusID;


            _db.SaveChanges();
            return res;
        }

        public Trip DeleteTrip(int id)
        {
            var delTripData = _db.Trips.FirstOrDefault(c => c.TripID == id);
            _db.Trips.Remove(delTripData);
            _db.SaveChanges();
            return delTripData;
        }
    }
}
