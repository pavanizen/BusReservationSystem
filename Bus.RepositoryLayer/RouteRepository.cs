using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bus.DataLayer;
using Bus.DomainModels.Models;
using Bus.RepositoryContract;

namespace Bus.RepositoryLayer
{
   public class RouteRepository:IRouteRepository
    {
        private readonly BusDbContext _db;

        public RouteRepository(BusDbContext db)
        {
            _db = db;
        }

        public List<Route> GetAllRouteDetails()
        {
            var routeData = _db.Routes.ToList();
            return routeData;
        }

        public Route GetRouteById(int id)
        {
            var singleData = _db.Routes.FirstOrDefault(b => b.RouteId == id);
            return singleData;
        }

        public Route AddRoute(Route route)
        {
            _db.Routes.Add(route);
            _db.SaveChanges();
            return route;
        }

        public Route EditRoute(int id, Route route)
        {
            var res = _db.Routes.FirstOrDefault(e => e.RouteId == id);
            res.FromLocation = route.FromLocation;
            res.ToLocation = route.ToLocation;
            res.Price = route.Price;

            _db.SaveChanges();
            return res;
        }

        public Route DeleteRoute(int id)
        {
            var delRouteData = _db.Routes.FirstOrDefault(c => c.RouteId == id);
            _db.Routes.Remove(delRouteData);
            _db.SaveChanges();
            return delRouteData;
        }
    }
}
