using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using T1RMSWS.Data;
using T1RMSWS.Models;

namespace T1RMSWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db; 

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db; 
        }

        public IActionResult Index()
        {
            var people = _db.People.ToList(); 
            return View();
        }

        public IActionResult Privacy(int? capacity)
        {

            var people = _db.People.ToList();
            ViewData["Test"] = (people.FirstOrDefault() != null).ToString();

            //var restaurant = _db.Restaurants.First();

            //var date = DateTime.Now;

            //var daysIntoTheFuture = 7;
            //var r = new Random();

            //for (int i = 0; i < daysIntoTheFuture; i++)
            //{
            //    var s = new Sitting
            //    {
            //        Start = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0),
            //        End = new DateTime(date.Year, date.Month, date.Day, 11, 30, 0),
            //        Restaurant = restaurant,
            //        SittingType = _db.SittingTypes.Find(r.Next(1, 4)),
            //        Capacity = capacity.HasValue ? capacity.Value : restaurant.SittingCapacity,
            //        Open = r.Next(0, 2) == 1
            //    };
            //    restaurant.Sittings.Add(s);
            //    date = date.AddDays(1);
            //}
            //_db.SaveChanges();

            return View();
        }
        public IActionResult Reservation()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult RedirectUser()
        {
            if (User.IsInRole("Manager"))
            {
                return RedirectToAction("Index", "Reports", new { area = "Management" });
            }
            else if (User.IsInRole("Member"))
            {
                return RedirectToAction("Index", "Reservation", new { area = "Member" });
            }
            else if (User.IsInRole("Staff"))
            {
                return RedirectToAction("Index", "Reservation", new { area = "Staff" });
            }
            return LocalRedirect("/");
        }
    }
}
