using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.December2020.Domain.Database;
using Hahn.ApplicatonProcess.December2020.Domain.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Repository;
using Hahn.ApplicatonProcess.December2020.Web.Validator;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    public class ApplicantModelsController : Controller
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantModelsController(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        // GET: ApplicantModels
        public async Task<IActionResult> Index()
        {
            return View(await _applicantRepository.GetAllApplicants());
        }

        // GET: ApplicantModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _applicantRepository.GetApplicant(id.Value);
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
        public async Task<IActionResult> Create([Bind("ID,Name,FamilyName,Address,CountryofOrigin,EMailAddress,Age,Hired")] ApplicantModelDto applicantModel)
        {
            if (ModelState.IsValid)
            {
                var validator = new ApplicantModelValidator();
                var results = validator.Validate(applicantModel);
                if (results.IsValid)
                {
                    ApplicantModel obj = new ApplicantModel();
                    obj.Name = applicantModel.Name;
                    obj.FamilyName = applicantModel.FamilyName;
                    obj.Age = applicantModel.Age;
                    obj.Address = applicantModel.Address;
                    obj.EMailAddress = applicantModel.EMailAddress;
                    obj.CountryofOrigin = applicantModel.CountryofOrigin;
                    obj.Hired = applicantModel.Hired;
                    await _applicantRepository.Create(obj);
                    return RedirectToAction(nameof(Index));
                }
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

            var applicantModel = await _applicantRepository.GetApplicant(id.Value);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,FamilyName,Address,CountryofOrigin,EMailAddress,Age,Hired")] ApplicantModelDto applicantModel)
        {
            if (id != applicantModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var validator = new ApplicantModelValidator();
                    var results = validator.Validate(applicantModel);
                    if (results.IsValid)
                    {
                        ApplicantModel obj = new ApplicantModel();
                        obj.Name = applicantModel.Name;
                        obj.FamilyName = applicantModel.FamilyName;
                        obj.Age = applicantModel.Age;
                        obj.Address = applicantModel.Address;
                        obj.EMailAddress = applicantModel.EMailAddress;
                        obj.CountryofOrigin = applicantModel.CountryofOrigin;
                        obj.Hired = applicantModel.Hired;
                        var update_applicant = await _applicantRepository.Update(id, obj);
                    }
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

            var applicantModel = await _applicantRepository.GetApplicant(id.Value);
            if (applicantModel != null)
            {
                return View(applicantModel);
            }
            return NotFound();
        }

        // POST: ApplicantModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicant = await _applicantRepository.Delete(id);

            if (applicant > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        private  bool ApplicantModelExists(int id)
        {
            var applicant = _applicantRepository.GetApplicant(id);
            if (applicant != null)
                return true;
            return false;
        }
    }
}
