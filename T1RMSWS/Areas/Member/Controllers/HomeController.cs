using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using T1RMSWS.Data;

namespace T1RMSWS.Areas.Member.Controllers
{
    public class HomeController : MemberAreaController
    {
        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager) 
            : base(context, userManager)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        
    }
}