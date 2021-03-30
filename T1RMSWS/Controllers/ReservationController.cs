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
    public class ReservationController : Controller
    {
        public ReservationController(ILogger<ReservationController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        private readonly ILogger<ReservationController> _logger;
        private readonly ApplicationDbContext _db;

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Form(int id, int guests)
        {
            var reservation = new Reservation();
            if (User.IsInRole("Member"))
            {
                var person = _db.People.FirstOrDefault(p => p.Email.Equals(User.Identity.Name));
                reservation.Customer = person as Customer;
                reservation.CustomerId = person.Id;
            }
            reservation.SittingId = id;
            reservation.Sitting = _db.Sittings.FirstOrDefault(r => r.Id.Equals(id));
            reservation.Guests = guests;
            if (reservation.Sitting == null)
            {
                return NotFound();
            }

            _logger.LogInformation("A form with id of " + id + " and guests of " + guests + " was requested at " + DateTime.Now);

            return View(reservation);
        }
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}