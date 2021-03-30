using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace T1RMSWS.Areas.Management.Controllers
{
    public class ReservationController : ManagementAreaController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}