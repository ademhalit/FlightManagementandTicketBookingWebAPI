using flightandticketproject.Data;
using flightandticketproject.Models;

namespace flightandticketproject.Services
{
    public class FlightService
    {
        private readonly ApplicationDbContext _context;

        public FlightService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Flight> GetAllFlights()
        {
            return _context.Flights.ToList();
        }

        public Flight? GetFlightById(int id)
        {
            return _context.Flights.Find(id);
        }

        public Flight CreateFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
            return flight;
        }

        public bool UpdateFlight(int id, Flight updated)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null) return false;

            flight.FlightNumber = updated.FlightNumber;
            flight.Airline = updated.Airline;
            flight.Origin = updated.Origin;
            flight.Destination = updated.Destination;
            flight.Departure = updated.Departure;
            flight.Price = updated.Price;
            flight.SeatsTotal = updated.SeatsTotal;
            flight.SeatsAvailable = updated.SeatsAvailable;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteFlight(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null) return false;

            _context.Flights.Remove(flight);
            _context.SaveChanges();
            return true;
        }
    }
}