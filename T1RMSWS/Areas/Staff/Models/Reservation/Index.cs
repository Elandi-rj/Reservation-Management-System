using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1RMSWS.Areas.Staff.Models.Reservation
{
    public class Index
    {
        public List<T1RMSWS.Data.Reservation> Reservations { get; set; }
        public List<SelectListItem> ReservationStatuses { get; set; }
        public List<SelectListItem> ReservationTypes { get; set; }
    }
}
