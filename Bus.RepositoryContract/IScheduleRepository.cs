using System;
using System.Collections.Generic;
using System.Text;
using Bus.DomainModels.Models;

namespace Bus.RepositoryContract
{
    public interface IScheduleRepository
    {
        List<Trip> GetAllTripDetails(); //all items
        Trip GetTripById(int id); //single item
        Trip AddTrip(Trip trip); //add trip
        Trip EditTrip(int id, Trip trip); //edit trip details
        Trip DeleteTrip(int id); //delete trip
    }
}
