using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T1RMSWS.Data;

namespace T1RMSWS.Areas.Management.Controllers
{
    public class ReportsController : ManagementAreaController
    {
        private readonly ApplicationDbContext _context;
        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var reservations = _context.Reservations.Where(r => r.StartTime.Year == DateTime.Now.Year).ToList();
            return View(reservations);
        }
        /// <summary>  
        /// get a list of all reservations made within a month
        /// </summary>  
        /// <returns>object with number of reservations and the string name of that month</returns>  
        /// 
        [HttpGet]
        public object GetReservations()
        {
            var months = new int[12];
            var reservations = _context.Reservations.Where(r => r.StartTime.Year == DateTime.Now.Year).ToList();
            foreach (var item in reservations)
            {
                months[item.StartTime.Month - 1] += 1;
            }

            var monthsdata = new ArrayList();
            for (int i = 0; i < months.Length; i++)
            {
                var obj = new ArrayList()
                {
                    DateTimeFormatInfo.CurrentInfo.GetMonthName(i + 1),
                    months[i]
                };
                monthsdata.Add(obj);
            }

            return monthsdata;
        }
        /// <summary>  
        /// gets the number all reservations in each status i.e pending, confirmed etc
        /// </summary>  
        /// <returns>returns data object with a string of the status and the number of reservations in that status</returns>  
        /// 
        [HttpGet]
        public object GetReservationsStatus()
        {
            var reservations = _context.Reservations.Where(r => r.StartTime.Year == DateTime.Now.Year).ToList();

            var total = reservations.Count();
            var pending = reservations.Where(r => r.ReservationStatusId == 1).Count();
            var confirmed = reservations.Where(r => r.ReservationStatusId == 2).Count();
            var cancelled = reservations.Where(r => r.ReservationStatusId == 3).Count();
            var seated = reservations.Where(r => r.ReservationStatusId == 4).Count();

            var data = new ArrayList()
            {
                new ArrayList()
                {
                    "Pending",
                    pending
                },
                new ArrayList()
                {
                    "Confirmed",
                    confirmed
                },
                new ArrayList()
                {
                    "Cancelled",
                    cancelled
                },
                new ArrayList()
                {
                    "Seated",
                    seated
                }
            };

            return data;
        }
        /// <summary>  
        /// gets the number all reservations in each type i.e online, mobile etc
        /// </summary>  
        /// <returns>returns data object with a string of the type and the number of reservations in that type</returns>  
        /// 
        [HttpGet]
        public object GetReservationsTypes()
        {
            var reservations = _context.Reservations.Where(r => r.StartTime.Year == DateTime.Now.Year).ToList();

            var online = reservations.Where(r => r.ReservationTypeId == 1).Count();
            var mobile = reservations.Where(r => r.ReservationTypeId == 2).Count();
            var inPerson = reservations.Where(r => r.ReservationTypeId == 3).Count();
            var email = reservations.Where(r => r.ReservationTypeId == 4).Count();
            var phone = reservations.Where(r => r.ReservationTypeId == 5).Count();

            var data = new ArrayList()
            {
                new ArrayList()
                {
                    "Online",
                    online
                },
                new ArrayList()
                {
                    "Mobile",
                    mobile
                },
                new ArrayList()
                {
                    "In-Person",
                    inPerson
                },
                new ArrayList()
                {
                    "Email",
                    email
                },
                new ArrayList()
                {
                    "Phone",
                    phone
                }
            };
            return data;
        }
    }
}