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
    public class SittingTypesController : ManagementAreaController
    {
        private readonly ApplicationDbContext _context;

        public SittingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Management/SittingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SittingTypes.ToListAsync());
        }

        // GET: Management/SittingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sittingType = await _context.SittingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sittingType == null)
            {
                return NotFound();
            }

            return View(sittingType);
        }

        // GET: Management/SittingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Management/SittingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] SittingType sittingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sittingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sittingType);
        }

        // GET: Management/SittingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sittingType = await _context.SittingTypes.FindAsync(id);
            if (sittingType == null)
            {
                return NotFound();
            }
            return View(sittingType);
        }

        // POST: Management/SittingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] SittingType sittingType)
        {
            if (id != sittingType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sittingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingTypeExists(sittingType.Id))
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
            return View(sittingType);
        }

        // GET: Management/SittingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sittingType = await _context.SittingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sittingType == null)
            {
                return NotFound();
            }

            return View(sittingType);
        }

        // POST: Management/SittingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sittingType = await _context.SittingTypes.FindAsync(id);
            _context.SittingTypes.Remove(sittingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SittingTypeExists(int id)
        {
            return _context.SittingTypes.Any(e => e.Id == id);
        }
    }
}
