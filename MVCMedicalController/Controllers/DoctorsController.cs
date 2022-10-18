using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCMedicalController.Data;
using MVCMedicalController.Models;

namespace MVCMedicalController.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly MedicalContextDB _context;

        public DoctorsController(MedicalContextDB context)
        {
            _context = context;
        }

        // GET: Doctors
        //public async Task<IActionResult> Index()
        //{
        //    var medicalContextDB = _context.Doctors.Include(d => d.Cabinet).Include(d => d.Sector).Include(d => d.Speciality);
        //    return View(await medicalContextDB.ToListAsync());
        //}

        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            var doctors = from m in _context.Doctors.Include(d => d.Cabinet).Include(d => d.Sector).Include(d => d.Speciality)
                         select m;

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                doctors = doctors.Where(s => s.DoctorSoName.Contains(searchString) || s.DoctorName.Contains(searchString) || s.DoctorFatherName.Contains(searchString)) ;
            }


            ViewData["DoctorName"] = String.IsNullOrEmpty(sortOrder) ? "DoctorName" : "";
            ViewData["DoctorSoName"] = String.IsNullOrEmpty(sortOrder) ? "DoctorSoName" : "";
            ViewData["DoctorFatherName"] = String.IsNullOrEmpty(sortOrder) ? "DoctorFatherName" : "";
            ViewData["Speciality"] = String.IsNullOrEmpty(sortOrder) ? "Speciality" : "";
            switch (sortOrder)
            {
                case "DoctorName":
                    doctors = doctors.OrderByDescending(s => s.DoctorName);
                    break;
                case "DoctorSoName":
                    doctors = doctors.OrderByDescending(s => s.DoctorSoName);
                    break;
                case "DoctorFatherName":
                    doctors = doctors.OrderByDescending(s => s.DoctorFatherName);
                    break;
                case "Speciality":
                    doctors = doctors.OrderByDescending(s => s.Speciality);
                    break;
                default:
                    doctors = doctors.OrderBy(s => s.DoctorSoName);
                    break;
            }
            return View(await doctors.ToListAsync());
        }


        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(d => d.Sector)
                .Include(d => d.Speciality)
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewData["CabinetID"] = new SelectList(_context.Cabinets, "CabinetID", "CabinetNumber");
            ViewData["SectorID"] = new SelectList(_context.Sectors, "SectorID", "SectorName");
            ViewData["SpecialityID"] = new SelectList(_context.Specialties, "SpecialityID", "SpecialityName");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorID,DoctorSoName,DoctorName,DoctorFatherName,CabinetID,SpecialityID,SectorID")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CabinetID"] = new SelectList(_context.Cabinets, "CabinetID", "CabinetNumber", doctor.CabinetID);
            ViewData["SectorID"] = new SelectList(_context.Sectors, "SectorID", "SectorName", doctor.SectorID);
            ViewData["SpecialityID"] = new SelectList(_context.Specialties, "SpecialityID", "SpecialityName", doctor.SpecialityID);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["CabinetID"] = new SelectList(_context.Cabinets, "CabinetID", "CabinetNumber", doctor.CabinetID);
            ViewData["SectorID"] = new SelectList(_context.Sectors, "SectorID", "SectorName", doctor.SectorID);
            ViewData["SpecialityID"] = new SelectList(_context.Specialties, "SpecialityID", "SpecialityName", doctor.SpecialityID);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorID,DoctorSoName,DoctorName,DoctorFatherName,CabinetID,SpecialityID,SectorID")] Doctor doctor)
        {
            if (id != doctor.DoctorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.DoctorID))
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
            ViewData["CabinetID"] = new SelectList(_context.Cabinets, "CabinetID", "CabinetNumber", doctor.CabinetID);
            ViewData["SectorID"] = new SelectList(_context.Sectors, "SectorID", "SectorName", doctor.SectorID);
            ViewData["SpecialityID"] = new SelectList(_context.Specialties, "SpecialityID", "SpecialityName", doctor.SpecialityID);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(d => d.Sector)
                .Include(d => d.Speciality)
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctors == null)
            {
                return Problem("Entity set 'MedicalContextDB.Doctors'  is null.");
            }
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
          return _context.Doctors.Any(e => e.DoctorID == id);
        }
    }
}
