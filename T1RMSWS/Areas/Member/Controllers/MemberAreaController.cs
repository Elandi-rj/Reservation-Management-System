using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T1RMSWS.Data;

namespace T1RMSWS.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class MemberAreaController : Controller
    {
        //add fields for context and user manager
        protected readonly UserManager<IdentityUser> _userManager;
        protected readonly ApplicationDbContext _context;
        /// <summary>  
        /// gets the identity user of the person on the page
        /// </summary>  
        /// <returns>returns identity user </returns>  
        /// 
        protected async Task<IdentityUser> GetIdentityUserAsync()
        {
            var u = User; //User is a predefined User from entity framework
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return user;
        }
        /// <summary>  
        /// gets the Person object of the user on the page
        /// </summary>  
        /// <returns>returns Person object of the user on the page</returns>  
        /// 
        protected async Task<Person> GetMemberAsync()
        {
            var user = await GetIdentityUserAsync();
            var person = await _context.People.FirstOrDefaultAsync(p => p.UserId.Equals(user.Id));
            return person;
        }
        /// <summary>  
        /// gets all reservations made by the member
        /// </summary>  
        /// <returns>returns list of reservations made by member </returns>  
        /// 
        protected async Task<List<Reservation>> GetMemberReservationsAsync()
        {
            var person = await GetMemberAsync();
            var reservations = _context.Reservations.Where(r => r.CustomerId == person.Id).ToList();

            return reservations;
        }
        public MemberAreaController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
    }
}