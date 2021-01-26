using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.December2020.Domain.Model;

namespace Hahn.ApplicatonProcess.December2020.Domain.Database
{
	public class ApplicantContext : DbContext
	{
		public ApplicantContext(DbContextOptions<ApplicantContext> options)
			: base(options)
		{

		}

		public DbSet<ApplicantModel> Applicants { get; set; }
	}
}
