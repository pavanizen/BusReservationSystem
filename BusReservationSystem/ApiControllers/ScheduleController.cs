using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bus.DataLayer;
using Bus.DomainModels.Models;
using Bus.RepositoryContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusReservationSystem.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public IActionResult Get()
        {
            var tripData = _scheduleRepository.GetAllTripDetails();
            return Ok(tripData);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var singleData = _scheduleRepository.GetTripById(id);
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
        public IActionResult AddNewTrip([FromBody] Trip trip)
        {
            var addRoute = _scheduleRepository.AddTrip(trip);
            return Ok(addRoute);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrip(int id, [FromBody] Trip trip)
        {
            var resUpdate = _scheduleRepository.EditTrip(id, trip);
            return Ok(resUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _scheduleRepository.DeleteTrip(id);
            return Ok(result);
        }
    }
}
