using Microsoft.AspNetCore.Mvc;
using flightandticketproject.Models;
using flightandticketproject.Services;

namespace flightandticketproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly FlightService _flightService;

        public FlightsController(FlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public IActionResult GetFlights()
        {
            var flights = _flightService.GetAllFlights();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight = _flightService.GetFlightById(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [HttpPost]
        public IActionResult CreateFlight([FromBody] Flight flight)
        {
            var created = _flightService.CreateFlight(flight);
            return CreatedAtAction(nameof(GetFlight), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFlight(int id, [FromBody] Flight flight)
        {
            var success = _flightService.UpdateFlight(id, flight);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFlight(int id)
        {
            var success = _flightService.DeleteFlight(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}