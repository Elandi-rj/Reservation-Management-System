using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using T1RMSWS.Data;

namespace T1RMSWS.Controllers
{
    public class ApiReservationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ReservationController> _logger;
        public ApiReservationController(ApplicationDbContext db, ILogger<ReservationController> logger)
        {
            _logger = logger;
            _db = db;
        }
        /// <summary>  
        /// get the unavailable starting times from the database
        /// </summary>  
        /// <param name="sittingId">integer Id of the sitting</param>  
        /// <param name="guests">integer number of guests</param>  
        /// <returns>list of strings representing the unavailable time slots</returns>  
        /// 
        [HttpGet]
        public async Task<List<List<string>>> GetStartSlots(int sittingId, int guests)
        {
            var sitting = await _db.Sittings
                .Where(s => s.Id == sittingId)
                .Include(s => s.SittingType)
                .Include(r => r.Reservations)
                .FirstOrDefaultAsync();

            int[] slots = sitting.GetSlots();
            DateTime start = sitting.Start;
            var unavailableSlots = new List<List<string>>();

            for (int i = 0; i < slots.Length; i++)
            {
                if (!(guests + slots[i] <= sitting.Capacity))
                {
                    DateTime time = start.AddHours((double)i / 2);
                    var nonSlot = new List<string>{
                        time.ToString("h:mmtt"),
                        time.AddHours(0.5).ToString("h:mmtt")
                    };
                    unavailableSlots.Add(nonSlot);
                }
            }
            _logger.LogInformation("a HttpGet request for getting start slots was made with sitting id of " + sittingId + " as the request at " + DateTime.Now);
            return unavailableSlots;
        }
        /// <summary>  
        /// get the unavailable duration times from the database
        /// </summary>  
        /// <param name="sittingId">integer Id of the sitting</param>  
        /// <param name="guests">integer number of guests</param>  
        /// <param name="startTime">DateTime starting time of the reservation reqeust</param>  
        /// <returns>list of strings representing the unavailable time slots</returns>  
        /// 
        [HttpGet]
        public async Task<List<string>> GetDuration(int sittingId, int guests, DateTime startTime)
        {
            var sitting = await _db.Sittings
                .Where(s => s.Id == sittingId)
                .Include(s => s.SittingType)
                .Include(r => r.Reservations)
                .FirstOrDefaultAsync();

            DateTime ss = sitting.Start;
            DateTime rs = new DateTime(ss.Year, ss.Month, ss.Day, startTime.Hour, startTime.Minute, startTime.Second); //transplanting reservation hours into sitting date.

            int[] slots = sitting.GetSlots();
            int index = (int)((rs - ss).TotalHours * 2);

            DateTime end = sitting.End; ;
            DateTime start = rs.AddHours(0.5);

            for (int i = index; i < slots.Length; i++)
            {
                var slotCapacity = guests + slots[i];
                if (slotCapacity > sitting.Capacity)
                {
                    end = ss.AddHours((((double)i - 1) / 2) + 0.5);
                    if (i - 1 == index)
                    {
                        start.AddHours(-0.5);
                    }
                    break;
                }
            }

            var times = new List<string>();
            times.Add(end.ToString("h:mmtt"));
            times.Add(start.ToString("h:mmtt"));

            return times;
        }
        /// <summary>  
        /// Responsible for processing reservation requests
        /// </summary>  
        /// <param name="r">Reservation object</param>  
        /// <returns>returns an object with a boolean value for if the reservation was accepted, and the a description of the error if it wasn't </returns>  
        /// 
        [HttpPost]
        public async Task<object> Submit(Reservation r)
        {
            bool valid = true;
            string errorMsg = "";
            try
            {
                var sitting = await _db.Sittings.Where(s => s.Id == r.SittingId).FirstOrDefaultAsync();
                //var CustId = r.Customer.Id;

                if (r.Customer.FirstName == null || r.Customer.LastName == null ||
                r.Customer.PhoneNumber == null || r.Customer.Email == null)
                {
                    valid = false;
                    errorMsg += "A field is invalid and or missing";
                }
                if (!sitting.Open)
                {
                    valid = false; errorMsg += "That sitting is closed";
                }
                if (r.Guests <= 0 || r.Guests > sitting.Capacity)
                {
                    valid = false;
                    errorMsg += "Guests number is invalid<br>";
                }

                if (valid)
                {
                    DateTime ss = sitting.Start;
                    DateTime se = sitting.End;
                    DateTime rs = new DateTime(ss.Year, ss.Month, ss.Day, r.StartTime.Hour, r.StartTime.Minute, r.StartTime.Second); //transplanting reservation hours into sitting date.
                    DateTime rd = new DateTime(ss.Year, ss.Month, ss.Day, r.Duration.Hour, r.Duration.Minute, r.Duration.Second); //transplanting reservation hours into sitting date.
                    string rsNormalized = rs.ToString("h:mmtt");

                    if (rs < ss || rs > se.AddHours(-0.5) || rs.Minute % 30 != 0)
                    {
                        valid = false;
                        errorMsg += "Start time is invalid<br>";
                    }
                    else
                    {
                        DateTime d = DateTime.Parse((await GetDuration(r.SittingId, r.Guests, rs))[0]);
                        DateTime duration = new DateTime(ss.Year, ss.Month, ss.Day, d.Hour, d.Minute, d.Second);
                        if (rd < rs.AddHours(0.5) || rd > duration || rd.Minute % 30 != 0)
                        {
                            valid = false;
                            errorMsg += "Duration is invalid<br>";
                        }
                    }

                    var slots = await GetStartSlots(r.SittingId, r.Guests);
                    var invalidTimes = new List<string>();
                    if (slots.Count > 0)
                    {
                        foreach (var item in slots)
                        {
                            invalidTimes.Add(item[0]);
                        }
                    }

                    foreach (var slot in invalidTimes)
                    {
                        if (slot.Contains(rsNormalized))
                        {
                            valid = false;
                            errorMsg += "Start time is invalid<br>";
                        }
                    }
                    if (r.Customer.Id == 0)
                    { //logged out
                        _db.Customers.Add(r.Customer);
                        _logger.LogInformation("A new customer was registered into the database name of " + r.Customer.FirstName + " " + r.Customer.LastName + " at " + DateTime.Now);
                    }
                    else
                    { //logged in
                        _db.Customers.Update(r.Customer);
                        _logger.LogInformation("A customer was updated in the database with a id of " + r.Customer.Id + " at " + DateTime.Now);
                    }
                    if (valid)
                    {
                        r.StartTime = rs;
                        r.Duration = rd;
                        _db.Reservations.Add(r);
                        _db.SaveChanges();
                    }
                    else
                    {
                        _logger.LogError("A reservation request had an error which was " + errorMsg + " at " + DateTime.Now);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg += ex.ToString();
                valid = false;
                _logger.LogError("A reservation request had an exception error which was " + ex.ToString() + " at " + DateTime.Now);
            }
            using (FileStream myFileStream = new FileStream("ReservationRequestDebug.txt", FileMode.Append))
            {
                TextWriterTraceListener listener = new TextWriterTraceListener(myFileStream);
                Trace.Listeners.Add(listener);
                Debug.Assert(valid, errorMsg);
                Debug.Close();
                Trace.Close();
            }
            return new { Valid = valid, Error = errorMsg };
        }
        /// <summary>  
        /// Get all reservation requests made by a member
        /// </summary>  
        /// <param name="email">string email</param>  
        /// <returns>list of objects with all details of a reservation made by the member</returns>  
        /// 
        [HttpGet]
        public async Task<IActionResult> ReservationByEmail(string email)
        {
            var person = await _db.People.Where(p => p.Email == email).FirstOrDefaultAsync();
            if (person == null) 
            { 
                return NotFound();  
            }
            var result = await _db.Reservations
                .Include(r => r.Sitting)
                    .ThenInclude(s => s.Restaurant)
                .Include(r => r.ReservationStatus)
                .Include(r => r.ReservationType)
                .Where(r => r.CustomerId == person.Id)
                .Select(r => new {
                    person = new
                    {
                        person.FirstName,
                        person.LastName,
                        person.PhoneNumber
                    },
                    r.Id,
                    r.Note,
                    r.Guests,
                    r.StartTime,
                    Duration = r.Duration.Subtract(r.StartTime).TotalHours,
                    r.ReservationStatusId,
                    ReservationStatus = new 
                    { 
                        r.ReservationStatus.Id,
                        r.ReservationStatus.Description
                    },
                    r.ReservationTypeId,
                    ReservationType = new
                    {
                        r.ReservationType.Id,
                        r.ReservationType.Description
                    },
                    r.SittingId,
                    Sitting = new 
                    { 
                        r.Sitting.Id,
                        r.Sitting.Open,
                    },
                    Restaurant = new 
                    { 
                        r.Sitting.Restaurant.Id,
                        r.Sitting.Restaurant.Phone,
                        r.Sitting.Restaurant.Address,
                        r.Sitting.Restaurant.Email
                    }
                })
                .ToListAsync();
            return Ok(result);
        }
    }
}