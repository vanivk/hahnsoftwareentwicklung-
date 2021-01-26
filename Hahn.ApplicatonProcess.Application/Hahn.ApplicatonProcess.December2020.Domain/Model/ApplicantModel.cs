using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data;

namespace Hahn.ApplicatonProcess.December2020.Domain.Model
{
	public class ApplicantModel
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryofOrigin { get; set; }
        public string EMailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }

        public ApplicantModel()
        {

        }
        public ApplicantModel(Applicant applicant)
        {
            ID = applicant.ID;
            Name = applicant.Name;
            FamilyName = applicant.FamilyName;
            Address = applicant.Address;
            EMailAddress = applicant.EMailAdress;
            Age = applicant.Age;
            Hired = applicant.Hired;
            CountryofOrigin = applicant.CountryOfOrigin;
        }
    }
}
