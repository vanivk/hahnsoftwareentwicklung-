using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.December2020.Domain.Database
{
	public class DataGenerator
	{
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicantContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicantContext>>()))
            {

                if (context.Applicants.Any())
                {
                    return;
                }

                context.Applicants.AddRange(
                    new Model.ApplicantModel
                    {
                        ID = 1,
                        Name = "First Test",
                        FamilyName = "Family1",
                        Address = "Mumbai",
                        Age = 20,
                        EMailAddress = "test@gmail.com",
                        CountryofOrigin = "India",
                        Hired = true

                    },
                    new Model.ApplicantModel
                    {
                        ID = 2,
                        Name = "Second Test",
                        FamilyName = "Family2",
                        Address = "Bengaluru",
                        Age = 22,
                        EMailAddress = "test2@gmail.com",
                        CountryofOrigin = "India",
                        Hired = false
                    },
                    new Model.ApplicantModel
                    {
                        ID = 3,
                        Name = "Third Test",
                        FamilyName = "Family3",
                        Address = "Delhi",
                        Age = 24,
                        EMailAddress = "test3@gmail.com",
                        CountryofOrigin = "India",
                        Hired = false
                    },

                    new Model.ApplicantModel
                    {
                        ID = 4,
                        Name = "Fourth Test",
                        FamilyName = "Family4",
                        Address = "Hyderabad",
                        Age = 27,
                        EMailAddress = "test4@gmail.com",
                        CountryofOrigin = "India",
                        Hired = true
                    });

                context.SaveChanges();
            }
        }
    }
}
