using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T1RMSWS.Data;

namespace T1RMSWS.Areas.Member.Controllers
{
    public class ReservationController : MemberAreaController
    {
        public ReservationController(ApplicationDbContext context, UserManager<IdentityUser> userManager) 
            : base(context, userManager)
        {
        }

        public async Task<IActionResult> Index()
        {
            //var user = await GetIdentityUserAsync();
            //var person = await GetMemberAsync();

            return View(await GetMemberReservationsAsync());
        }
    }
}