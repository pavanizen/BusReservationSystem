using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bus.DataLayer;
using Bus.DomainModels.Models;
using Bus.RepositoryContract;
using BusReservationSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusReservationSystem.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelRepository _travelRepository;

        public TravelController(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public IActionResult Get()
        {
            var busData = _travelRepository.GetAllBusDetails();
            return Ok(busData);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var singleData = _travelRepository.GetBusById(id);
            if (singleData != null)
            {
                return Ok(singleData);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddNewBus([FromBody] BusDetails busDetails)
        {
            var addBus = _travelRepository.AddBus(busDetails);
            return Ok(addBus);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBus(int id, [FromBody] BusDetails busDetails)
        {
            var resUpdate = _travelRepository.EditBus(id, busDetails);
            return Ok(resUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _travelRepository.DeleteBus(id);
            return Ok(result);
        }
    }
}
