using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace T1RMSWS.Data
{
    public class ReservationTable

    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        
    }
}