using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Repository;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Web.Validator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicantController : ControllerBase
	{

		private readonly IApplicantRepository _applicantRepository;
		public ApplicantController(IApplicantRepository applicantRepository)
		{
			_applicantRepository = applicantRepository;
		}


		// GET: api/<ApplicantController>
		[HttpGet]
		public IActionResult GetAllApplicants()
		{
			var data = _applicantRepository.GetAllApplicants();

			return Ok(data);
		}

		// GET api/<ApplicantController>/5
		[HttpGet]
		[Route("GetApplicant")]
		public async Task<IActionResult> GetApplicant(int id)
		{
			var applicant = await _applicantRepository.GetApplicant(id);

			return Ok(applicant);
		}

		// POST api/<ApplicantController>
		[HttpPost]
		[Route("CreateApplicant")]
		public async Task<IActionResult> CreateApplicant([FromBody] ApplicantModelDto applicantModel)
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
				var postapplicant = await _applicantRepository.Create(obj);

				if (postapplicant > 0)
				{
					return Ok(postapplicant);
				}
				else
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}

		// PUT api/<ApplicantController>/5
		[HttpPut]
		[Route("UpdateApplicant")]
		public async Task<IActionResult> UpdateApplicant(int id, ApplicantModelDto applicantModel)
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


				if (update_applicant > 0)
				{
					return Ok(update_applicant);
				}
				else
				{
					return BadRequest();
				}
			}
			return BadRequest();
		}

		// DELETE api/<ApplicantController>/5
		[HttpDelete]
		[Route("DeleteApplicant")]
		public async Task<IActionResult> DeleteApplicant(int id)
		{
			var applicant = await _applicantRepository.Delete(id);

			if (applicant > 0)
			{
				return Ok("Deleted");
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
