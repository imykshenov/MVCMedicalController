using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCMedicalController.Data;
using MVCMedicalController.Models;
using MVCMedicalController.Modules;

namespace MVCMedicalController.Controllers
{
    public class PatientsController : Controller
    {
        private readonly MedicalContextDB _context;

        public PatientsController(MedicalContextDB context)
        {
            _context = context;
        }

        // GET: Patients
        //public async Task<IActionResult> Index()
        //{
        //    var medicalContextDB = _context.Patients.Include(p => p.Sector);
        //    return View(await medicalContextDB.ToListAsync());
        //}

        public async Task<IActionResult> Index(string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            var patients = from s in _context.Patients
                select s;
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(s => s.PatientName.Contains(searchString) || s.PatientSoName.Contains(searchString) || s.PatientFatherName.Contains(searchString));
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["PatientName"] = String.IsNullOrEmpty(sortOrder) ? "PatientName" : "";
            ViewData["PatientSoName"] = String.IsNullOrEmpty(sortOrder) ? "PatientSoName" : "";
            ViewData["PatientFatherName"] = String.IsNullOrEmpty(sortOrder) ? "PatientFatherName" : "";
            ViewData["DateOfBirth"] = String.IsNullOrEmpty(sortOrder) ? "DateOfBirth" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            switch (sortOrder)
            {
                case "PatientName":
                    patients = patients.OrderByDescending(s => s.PatientName);
                    break;
                case "PatientSoName":
                    patients = patients.OrderByDescending(s => s.PatientSoName);
                    break;
                case "PatientFatherName":
                    patients = patients.OrderByDescending(s => s.PatientFatherName);
                    break;
                case "DateOfBirth":
                    patients = patients.OrderByDescending(s => s.DateOfBirth);
                    break;
                
                default:
                    patients = patients.OrderBy(s => s.PatientSoName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Patient>.CreateAsync(patients.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .Include(p => p.Sector)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["sectorID"] = new SelectList(_context.Sectors, "SectorID", "SectorName");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,PatientSoName,PatientName,PatientFatherName,Adress,DateOfBirth,Sex,sectorID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["sectorID"] = new SelectList(_context.Sectors, "SectorID", "SectorName", patient.sectorID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["sectorID"] = new SelectList(_context.Sectors, "SectorID", "SectorName", patient.sectorID);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,PatientSoName,PatientName,PatientFatherName,Adress,DateOfBirth,Sex,sectorID")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientId))
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
            ViewData["sectorID"] = new SelectList(_context.Sectors, "SectorID", "SectorName", patient.sectorID);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .Include(p => p.Sector)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Patients == null)
            {
                return Problem("Entity set 'MedicalContextDB.Patient'  is null.");
            }
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
          return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}
