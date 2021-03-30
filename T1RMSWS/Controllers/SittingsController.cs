using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T1RMSWS.Data;

namespace T1RMSWS.Controllers
{
    public class SittingsController : Controller
    {

        public class Monthly
        {
            public int id { get; set; }
            public string name { get; set; }
            public string startdate { get; set; }
            public string enddate { get; set; }
            public string starttime { get; set; }
            public string endtime { get; set; }
            public string color { get; set; }
            public string url { get; set; }
        }
        public class RootObject
        {
            public List<Monthly> monthly { get; set; }
            public RootObject(List<Monthly> events) { monthly = events; }
        }

        private readonly ApplicationDbContext _db;

        public SittingsController(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>  
        /// generates object with list of reservations that are available and are able to fit the number of guests
        /// </summary>  
        /// <param name="guests">integer number of guests</param>  
        /// <returns>object with list of reservations that are available and are able to fit the number of guests</returns>  
        /// 
        [HttpPost]
        public object GetList(int guests)
        {
            var sittings = _db.Sittings.Include(s => s.SittingType).Include(r => r.Reservations);

            //generate list of times that are under the guest limit defined in reservations
            var availableSittings = new List<Sitting>();

            foreach (var sitting in sittings)
            {
                if (sitting.Reservations.Count == 0 && guests <= sitting.Capacity)
                {
                    availableSittings.Add(sitting);
                }
                else
                {
                    int[] slots = sitting.GetSlots();
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if ((guests + slots[i]) <= sitting.Capacity)
                        {
                            availableSittings.Add(sitting);
                            break;
                        }
                    }
                }
            }

            foreach (var sitting in sittings)
            {
                if (!availableSittings.Contains(sitting))
                {
                    sitting.Open = false;
                    availableSittings.Add(sitting);
                }
            }

            //generate list of events for api
            var eventList = new List<Monthly>();
            foreach (var item in availableSittings)
            {
                DateTime st = item.Start;
                DateTime et = item.End;
                string colour = "#b2b5c6";
                string url = "";
                string name = " (Reservation Unavailable)";

                if (item.Open)
                {
                    colour = "#f87698";
                    url = "/Reservation/Form?id=" + item.Id + "&guests=" + guests;
                    name = "";
                }
                var Event = new Monthly
                {
                    id = item.Id,
                    name = item.SittingType.Description + name,
                    startdate = st.ToString("yyyy-MM-dd"),
                    enddate = et.ToString("yyyy-MM-dd"),
                    starttime = st.ToString("h:mm"),
                    endtime = et.ToString("h:mm"),
                    color = colour,
                    url = url,
                };
                eventList.Add(Event);
            }
            var root = new RootObject(eventList);
            return root;
        }
    }
}