﻿using System;
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
        private readonly MedicalContextDB _context;

        public CabinetsController(MedicalContextDB context)
        {
            _context = context;
        }

        // GET: Cabinets
        public async Task<IActionResult> Index(string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            var cabinets = from m in _context.Cabinets
                select m;

            ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            int pageSize = 3;
            return View(await PaginatedList<Cabinet>.CreateAsync(cabinets.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Cabinets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cabinets == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinets
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
            if (id == null || _context.Cabinets == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinets.FindAsync(id);
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
            if (id == null || _context.Cabinets == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinets
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
            if (_context.Cabinets == null)
            {
                return Problem("Entity set 'MVCMedicalControllerContext.Cabinet'  is null.");
            }
            var cabinet = await _context.Cabinets.FindAsync(id);
            if (cabinet != null)
            {
                _context.Cabinets.Remove(cabinet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CabinetExists(int id)
        {
          return _context.Cabinets.Any(e => e.CabinetID == id);
        }
    }
}
