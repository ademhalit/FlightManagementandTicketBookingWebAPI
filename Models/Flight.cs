using flightandticketproject.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace flightandticketproject.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public decimal Price { get; set; }                
        public int SeatsTotal { get; set; }               
        public int SeatsAvailable { get; set; }           
        public byte[]? RowVersion { get; set; }

        [JsonIgnore]
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    }
}