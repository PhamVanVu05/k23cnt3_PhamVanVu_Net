using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamVanVu_2310900120.Models;

namespace PhamVanVu_2310900120.Controllers
{
    public class PvvEmployeesController : Controller
    {
        private readonly PhamVanVu2310900120Context _context;

        public PvvEmployeesController(PhamVanVu2310900120Context context)
        {
            _context = context;
        }

        // GET: PvvEmployees
        public async Task<IActionResult> PvvIndex()
        {
            return View(await _context.PvvEmployees.ToListAsync());
        }

        // GET: PvvEmployees/Details/5
        public async Task<IActionResult> PvvDetails(int? PvvId)
        {
            if (PvvId == null) return NotFound();
            var emp = await _context.PvvEmployees.FirstOrDefaultAsync(m => m.PvvEmpId == PvvId);
            return emp == null ? NotFound() : View(emp);
        }

        // GET: PvvEmployees/PvvCreate
        [HttpGet]
        public IActionResult PvvCreate()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PvvCreate(PvvEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PvvIndex));
            }
            return View(emp);
        }

        // GET: PvvEmployees/PvvEdit/5
        public async Task<IActionResult> PvvEdit(int? Pvvid)
        {
            if (Pvvid == null)
            {
                return NotFound();
            }

            var PvvEmployee = await _context.PvvEmployees.FindAsync(Pvvid);
            if (PvvEmployee == null)
            {
                return NotFound();
            }
            return View(PvvEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PvvEdit(int PvvId, PvvEmployee emp)
        {
            if (PvvId != emp.PvvEmpId) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.PvvEmployees.Any(e => e.PvvEmpId == emp.PvvEmpId))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(PvvIndex));
            }
            return View(emp);
        }


        public async Task<IActionResult> PvvDelete(int? PvvId)
        {
            if (PvvId == null) return NotFound();
            var emp = await _context.PvvEmployees.FirstOrDefaultAsync(m => m.PvvEmpId == PvvId);
            return emp == null ? NotFound() : View(emp);
        }

        [HttpPost, ActionName("PvvDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PvvDeleteConfirmed(int PvvId)
        {
            var emp = await _context.PvvEmployees.FindAsync(PvvId);
            if (emp != null)
            {
                _context.PvvEmployees.Remove(emp);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(PvvIndex));
        }
    }
}
