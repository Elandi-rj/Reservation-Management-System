using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1RMSWS.Data
{
    public class Sitting
    {
        public Sitting()
        {
            Reservations = new List<Reservation>();
        }
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int DurationHours { get { return (int)(End - Start).TotalHours; } }
        public int Capacity { get; set; }
        public bool Open { get; set; } = true;
        public int SittingTypeId { get; set; }
        public SittingType SittingType { get; set; }

        public List<Reservation> Reservations { get; set; }
        /// <summary>  
        /// Gets a int array of the number of guests in every 30 minute segment
        /// </summary>  
        /// <returns>return an int array of the number of guests in every 30 minute segment</returns>  
        /// 
        public int[] GetSlots()
        {
            // segment number of slots (30 minutes) between start of the reservation and the end of the reservation
            int slotNum = DurationHours * 2;
            int[] slots = new int[slotNum];
            foreach (var reservation in Reservations)
            {
                // slots difference between start of the sitting and start of the reservation
                var resSitStartOffset = (int)((reservation.StartTime - Start).TotalHours * 2);
                // slots difference between end of the sitting and start of the reservation
                var resSitEndOffset = (int)((reservation.Duration - Start).TotalHours * 2);
                for (int i = 0; i < slotNum; i++)
                {
                    if (resSitStartOffset <= i && resSitEndOffset > i)
                    {
                        slots[i] += reservation.Guests;
                    }
                }
            }
            return slots;
        }
    }
}
