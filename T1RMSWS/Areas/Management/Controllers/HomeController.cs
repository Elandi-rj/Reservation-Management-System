using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T1RMSWS.Data;

namespace T1RMSWS.Areas.Management.Controllers
{
    public class HomeController : ManagementAreaController
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservations.Include(r => r.ReservationStatus);
            return View(await applicationDbContext.ToListAsync());
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]

        public ActionResult Edit(int id, Reservation reservation) {
            
            return View();
        }


    }
}