using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T1RMSWS.Data;

namespace T1RMSWS.Areas.Management.Controllers
{
    [Area("Management")]
    public class SittingsController : ManagementAreaController
    {
        private readonly ApplicationDbContext _context;

        public SittingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Management/Sittings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sittings.Include(s => s.Restaurant).Include(s => s.SittingType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Management/Sittings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings
                .Include(s => s.Restaurant)
                .Include(s => s.SittingType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // GET: Management/Sittings/Create
        public IActionResult Create()
        {
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id");
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description");
            return View();
        }

        // POST: Management/Sittings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RestaurantId,Start,End,Capacity,Open,SittingTypeId")] Sitting sitting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sitting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", sitting.RestaurantId);
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description", sitting.SittingTypeId);
            return View(sitting);
        }

        // GET: Management/Sittings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings.FindAsync(id);
            if (sitting == null)
            {
                return NotFound();
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", sitting.RestaurantId);
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description", sitting.SittingTypeId);
            return View(sitting);
        }

        [HttpPost]
        public int MakeSittingType(string description)
        {
            var sittingType = new SittingType() { Description = description };
            _context.SittingTypes.Add(sittingType);
            _context.SaveChanges();
            return sittingType.Id;
        }
        // POST: Management/Sittings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RestaurantId,Start,End,Capacity,Open,SittingTypeId")] Sitting sitting)
        {
            if (id != sitting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sitting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingExists(sitting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "Id", "Id", sitting.RestaurantId);
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "Id", "Description", sitting.SittingTypeId);
            return View(sitting);
        }

        // GET: Management/Sittings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings
                .Include(s => s.Restaurant)
                .Include(s => s.SittingType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // POST: Management/Sittings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sitting = await _context.Sittings.FindAsync(id);
            _context.Sittings.Remove(sitting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SittingExists(int id)
        {
            return _context.Sittings.Any(e => e.Id == id);
        }
    }
}
