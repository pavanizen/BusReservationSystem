using System;
using System.Collections.Generic;
using System.Text;
using Bus.DomainModels.Models;

namespace Bus.RepositoryContract
{
    public interface ITravelRepository
    {
        List<BusDetails> GetAllBusDetails(); //all items
        BusDetails GetBusById(int id); //single item
        BusDetails AddBus(BusDetails busDetails); //add bus
        BusDetails EditBus(int id, BusDetails busDetails); //edit bus details
        BusDetails DeleteBus(int id); //delete bus
    }
}
