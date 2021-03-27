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
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository _routeRepository;

        public RouteController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public IActionResult Get()
        {
            var routeData = _routeRepository.GetAllRouteDetails();
            return Ok(routeData);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var singleData = _routeRepository.GetRouteById(id);
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
        public IActionResult AddNewRoute([FromBody] Route route)
        {
            var addRoute = _routeRepository.AddRoute(route);
            return Ok(addRoute);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoute(int id, [FromBody] Route route)
        {
            var resUpdate = _routeRepository.EditRoute(id, route);
            return Ok(resUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _routeRepository.DeleteRoute(id);
            return Ok(result);
        }
    }
}
