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
    public class SpecialitiesController : Controller
    {
        private readonly MVCMedicalControllerContext _context;

        public SpecialitiesController(MVCMedicalControllerContext context)
        {
            _context = context;
        }

        // GET: Specialities
        public async Task<IActionResult> Index()
        {
              return View(await _context.Speciality.ToListAsync());
        }

        // GET: Specialities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Speciality == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .FirstOrDefaultAsync(m => m.SpecialityID == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // GET: Specialities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialityID,SpecialityName")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speciality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speciality);
        }

        // GET: Specialities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Speciality == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }
            return View(speciality);
        }

        // POST: Specialities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialityID,SpecialityName")] Speciality speciality)
        {
            if (id != speciality.SpecialityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speciality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialityExists(speciality.SpecialityID))
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
            return View(speciality);
        }

        // GET: Specialities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Speciality == null)
            {
                return NotFound();
            }

            var speciality = await _context.Speciality
                .FirstOrDefaultAsync(m => m.SpecialityID == id);
            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        // POST: Specialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Speciality == null)
            {
                return Problem("Entity set 'MVCMedicalControllerContext.Speciality'  is null.");
            }
            var speciality = await _context.Speciality.FindAsync(id);
            if (speciality != null)
            {
                _context.Speciality.Remove(speciality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialityExists(int id)
        {
          return _context.Speciality.Any(e => e.SpecialityID == id);
        }
    }
}
