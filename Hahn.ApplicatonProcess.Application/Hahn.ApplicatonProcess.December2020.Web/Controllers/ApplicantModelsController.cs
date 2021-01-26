using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.December2020.Domain.Database;
using Hahn.ApplicatonProcess.December2020.Domain.Model;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    public class ApplicantModelsController : Controller
    {
        private readonly ApplicantContext _context;

        public ApplicantModelsController(ApplicantContext context)
        {
            _context = context;
        }

        // GET: ApplicantModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Applicants.ToListAsync());
        }

        // GET: ApplicantModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.Applicants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applicantModel == null)
            {
                return NotFound();
            }

            return View(applicantModel);
        }

        // GET: ApplicantModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicantModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,FamilyName,Address,CountryofOrigin,EMailAddress,Age,Hired")] ApplicantModel applicantModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicantModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicantModel);
        }

        // GET: ApplicantModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.Applicants.FindAsync(id);
            if (applicantModel == null)
            {
                return NotFound();
            }
            return View(applicantModel);
        }

        // POST: ApplicantModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,FamilyName,Address,CountryofOrigin,EMailAddress,Age,Hired")] ApplicantModel applicantModel)
        {
            if (id != applicantModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicantModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantModelExists(applicantModel.ID))
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
            return View(applicantModel);
        }

        // GET: ApplicantModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.Applicants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applicantModel == null)
            {
                return NotFound();
            }

            return View(applicantModel);
        }

        // POST: ApplicantModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicantModel = await _context.Applicants.FindAsync(id);
            _context.Applicants.Remove(applicantModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantModelExists(int id)
        {
            return _context.Applicants.Any(e => e.ID == id);
        }
    }
}
