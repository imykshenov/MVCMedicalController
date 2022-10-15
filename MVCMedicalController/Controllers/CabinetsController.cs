using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCMedicalController.Data;
using MVCMedicalController.Models;

namespace MVCMedicalController.Controllers
{
    public class CabinetsController : Controller
    {
        private readonly MVCMedicalControllerContext _context;

        public CabinetsController(MVCMedicalControllerContext context)
        {
            _context = context;
        }

        // GET: Cabinets
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cabinet.ToListAsync());
        }

        // GET: Cabinets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cabinet == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinet
                .FirstOrDefaultAsync(m => m.CabinetID == id);
            if (cabinet == null)
            {
                return NotFound();
            }

            return View(cabinet);
        }

        // GET: Cabinets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cabinets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CabinetID,CabinetNumber")] Cabinet cabinet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cabinet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cabinet);
        }

        // GET: Cabinets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cabinet == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinet.FindAsync(id);
            if (cabinet == null)
            {
                return NotFound();
            }
            return View(cabinet);
        }

        // POST: Cabinets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CabinetID,CabinetNumber")] Cabinet cabinet)
        {
            if (id != cabinet.CabinetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cabinet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CabinetExists(cabinet.CabinetID))
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
            return View(cabinet);
        }

        // GET: Cabinets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cabinet == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinet
                .FirstOrDefaultAsync(m => m.CabinetID == id);
            if (cabinet == null)
            {
                return NotFound();
            }

            return View(cabinet);
        }

        // POST: Cabinets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cabinet == null)
            {
                return Problem("Entity set 'MVCMedicalControllerContext.Cabinet'  is null.");
            }
            var cabinet = await _context.Cabinet.FindAsync(id);
            if (cabinet != null)
            {
                _context.Cabinet.Remove(cabinet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CabinetExists(int id)
        {
          return _context.Cabinet.Any(e => e.CabinetID == id);
        }
    }
}
