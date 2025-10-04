using flightandticketproject.Data;
using flightandticketproject.Models;
using Microsoft.EntityFrameworkCore;

namespace flightandticketproject.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets
        .Include(t => t.Flight)
        .ToList();
        }

        public Ticket? GetTicketById(int id)
        {
            return _context.Tickets
        .Include(t => t.Flight)
        .FirstOrDefault(t => t.Id == id);
        }

        public Ticket? BookTicket(int flightId, string passengerName, string seatNumber)
        {
            var flight = _context.Flights.Find(flightId);
            if (flight == null || flight.SeatsAvailable <= 0)
                return null;

            var ticket = new Ticket
            {
                PassengerName = passengerName,
                SeatNumber = seatNumber,
                FlightId = flightId,
                Price = flight.Price,
                BookedAt = DateTime.UtcNow,
                TicketGuid = Guid.NewGuid().ToString()
            };

            flight.SeatsAvailable -= 1;

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return ticket;
        }

        public bool DeleteTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null) return false;

            var flight = _context.Flights.Find(ticket.FlightId);
            if (flight != null)
                flight.SeatsAvailable += 1;

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return true;
        }
    }
}