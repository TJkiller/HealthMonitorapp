using HealthMonitorapp.Data;
using HealthMonitorapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitorapp.Controllers
{
    public class PatientDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientData
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientData.ToListAsync());
        }

        // GET: PatientData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,Timestamp,HeartRate,OxygenLevel,Alert")] PatientData patientData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientData);
        }

        // GET: PatientData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientData = await _context.PatientData.FindAsync(id);
            if (patientData == null)
            {
                return NotFound();
            }
            return View(patientData);
        }

        // POST: PatientData/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,Timestamp,HeartRate,OxygenLevel,Alert")] PatientData patientData)
        {
            if (id != patientData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDataExists(patientData.Id))
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
            return View(patientData);
        }

        // GET: PatientData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientData = await _context.PatientData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientData == null)
            {
                return NotFound();
            }

            return View(patientData);
        }

        // POST: PatientData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientData = await _context.PatientData.FindAsync(id);

            // Check if patient data exists before deleting
            if (patientData == null)
            {
                return NotFound(); // Return 404 if the data doesn't exist
            }

            _context.PatientData.Remove(patientData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool PatientDataExists(int id)
        {
            return _context.PatientData.Any(e => e.Id == id);
        }
    }
}
