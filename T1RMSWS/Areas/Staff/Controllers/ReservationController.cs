using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T1RMSWS.Data;

namespace T1RMSWS.Areas.Staff.Controllers
{
    public class ReservationController : StaffAreaController
    {
        private readonly ApplicationDbContext _context;
        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var m = new T1RMSWS.Areas.Staff.Models.Reservation.Index
            {
                Reservations = await _context.Reservations
                    .Include(r => r.ReservationType)
                    .Include(r => r.ReservationStatus)
                    .Include(r => r.Customer)
                    .Include(r=>r.Sitting)
                    .ThenInclude(s=>s.SittingType)
                    .ToListAsync(),
                ReservationStatuses = await _context.ReservationStatuses
                    .Select(rs=>new SelectListItem { Value=rs.Id.ToString(), Text=rs.Description})
                    .ToListAsync(),
                ReservationTypes = await _context.ReservationTypes
                    .Select(rt => new SelectListItem { Value = rt.Id.ToString(), Text = rt.Description })
                    .ToListAsync()
        };
  
            return View(m);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        

        [HttpGet]
        public async Task<IActionResult> Tables(int id) //Id is reservation id
        {
            var reservation = await _context.Reservations
                  .Include(r => r.AssignedTables)
                    .ThenInclude(at=>at.Table)
                    .ThenInclude(t=>t.Area)
                  .FirstOrDefaultAsync(r => r.Id == id);

            var overlappingTables = reservation.GetAllReservedTables(_context);

            if (reservation == null)
            {
                return NotFound();
            }
            var tables = (await _context.Tables
                 .ToListAsync())
                 .Where(t => !overlappingTables.Any(at => at.TableId == t.Id))
                 .ToList();

            ViewData["TableId"] = new SelectList(tables, "Id", "Description");
            return View(reservation);
        }
        /// <summary>  
        /// Creates a table in the database and redirects to table action
        /// </summary>  
        /// <param name="tableId">integer Id of the table</param>  
        /// <param name="reservationId">integer Id of the reservation</param>  
        /// <returns>returns redirect to action</returns>  
        /// 
        [HttpPost]
        public async Task<IActionResult> TablesCreate(int tableId, int reservationId)
        {
            try
            {
                var rt = new ReservationTable { TableId = tableId, ReservationId = reservationId };
                _context.ReservationTables.Add(rt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Tables), new { id = reservationId });
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Tables), new { id = reservationId });
            }
        }
        /// <summary>  
        /// Deletes a table from the database and redirects to table action
        /// </summary>  
        /// <param name="id">integer Id of the reservation</param>  
        /// <returns>returns redirect to action</returns>  
        /// 
        [HttpPost]
        public IActionResult TablesDelete(int id) //Id is tablereservation id
        {
            var table = _context.ReservationTables
                .Where(t => t.Id == id)
                .FirstOrDefault();
            _context.Remove(table);
            _context.SaveChanges();
            return RedirectToAction(nameof(Tables), new { id = table.ReservationId });
        }
    }
}