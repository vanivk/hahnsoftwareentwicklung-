using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Model;

namespace Hahn.ApplicatonProcess.December2020.Web.Validator
{
	public class ApplicantModelValidator : AbstractValidator<ApplicantModelDto>
	{
		public ApplicantModelValidator()
		{
			RuleSet("all", () =>
			{
				RuleFor(x => x.Name).NotNull().MinimumLength(5).WithMessage("Name could not be null and minimim length is 5 characters");
				RuleFor(x => x.FamilyName).NotNull().MinimumLength(5).WithMessage("Family name could not be null and minimim length has to be 5 characters");
				RuleFor(x => x.Address).NotNull().MinimumLength(10).WithMessage("Address could not be null and minimim length has to be 10 characters");
				RuleFor(x => x.CountryofOrigin).NotNull().MaximumLength(200).WithMessage("Country could not be null");
				RuleFor(x => x.EMailAddress).NotNull().EmailAddress().WithMessage("Please enter a valid email address.");
				RuleFor(x => x.Hired).NotNull().WithMessage("Please select atleast one value");
				RuleFor(x => x.Age).LessThan(60).GreaterThanOrEqualTo(20).NotNull().WithMessage("Please enter age between 20 and 60.");
			});
		}
	}
}
