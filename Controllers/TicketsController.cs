using Microsoft.AspNetCore.Mvc;
using flightandticketproject.Models;
using flightandticketproject.Services;

namespace flightandticketproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            var tickets = _ticketService.GetAllTickets();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public IActionResult GetTicket(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult BookTicket([FromBody] TicketBookingRequest request)
        {
            var ticket = _ticketService.BookTicket(request.FlightId, request.PassengerName, request.SeatNumber);
            if (ticket == null) return BadRequest("Flight not found or no seats available.");
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var success = _ticketService.DeleteTicket(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }

    public class TicketBookingRequest
    {
        public int FlightId { get; set; }
        public string PassengerName { get; set; }
        public string SeatNumber { get; set; }
    }
}