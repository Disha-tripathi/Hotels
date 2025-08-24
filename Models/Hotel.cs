using System;

namespace HotelAPI.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public int Rating { get; set; }
        public required string TeamInCharge { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
