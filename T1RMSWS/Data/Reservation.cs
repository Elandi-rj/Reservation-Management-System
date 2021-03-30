using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace T1RMSWS.Data
{
    public class Reservation
    {
        public Reservation()
        {
            AssignedTables = new List<ReservationTable>();
        }
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Duration { get; set; }
        public int Guests { get; set; }

        public int ReservationTypeId { get; set; }
        public ReservationType ReservationType { get; set; }

        public string Note { get; set; }

        public int ReservationStatusId { get; set; } = 1; // 1 should be equal to Pending in the database.
        public ReservationStatus ReservationStatus { get; set; }

        public List<ReservationTable> AssignedTables { get; set; } = null;

        public int SittingId { get; set; }
        public Sitting Sitting { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        /// <summary>  
        /// goes through each reservation in the same sitting as the chosen reservation, which has assigned table(s) and is overlapping with the chosen reservation
        /// </summary>  
        /// <param name="_db">database context</param>  
        /// <returns>list of ReservationTable objects that are assigned to this object</returns>  
        /// 
        public List<ReservationTable> GetAllReservedTables(ApplicationDbContext _db)
        {
            var assignedTables = _db.Reservations
                .Include(r => r.AssignedTables)
                .Where(r => r.SittingId == SittingId && r.StartTime < Duration && StartTime < r.Duration)
                .Select(t => t.AssignedTables)
                .ToList();
            var listTables = new List<ReservationTable>();
            foreach (var item in assignedTables)
            {
                foreach (var table in item)
                {
                    listTables.Add(table);
                }
            }
            return listTables;
        }
        public string getDescription(int i)
        {
            string description = "";

            switch (i)
            {
                case 1:
                    description = "Pending";
                    break;
                case 2:
                    description = "Confirmed";
                    break;
                case 3:
                    description = "Cancelled";
                    break;
                case 4:
                    description = "Seated";
                    break;
                case 5:
                    description = "Completed";
                    break;
            }
            return description;
        }
    }
}