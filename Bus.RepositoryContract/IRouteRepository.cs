using System;
using System.Collections.Generic;
using System.Text;
using Bus.DomainModels.Models;

namespace Bus.RepositoryContract
{
   public interface IRouteRepository
    {
        List<Route> GetAllRouteDetails(); //all items
        Route GetRouteById(int id); //single item
        Route AddRoute(Route route); //add route
        Route EditRoute(int id, Route route); //edit route details
        Route DeleteRoute(int id); //delete route

    }
}
