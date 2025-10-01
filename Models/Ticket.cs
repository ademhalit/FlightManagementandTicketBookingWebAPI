using flightandticketproject.Models;
using System;

namespace flightandticketproject.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketGuid { get; set; } = Guid.NewGuid().ToString();
        public string PassengerName { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public decimal Price { get; set; }       
        public string SeatNumber { get; set; }
        public DateTime BookedAt { get; set; } = DateTime.UtcNow;
    }
}