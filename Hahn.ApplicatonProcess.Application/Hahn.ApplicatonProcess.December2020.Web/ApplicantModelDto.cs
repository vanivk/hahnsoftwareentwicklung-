using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web
{
	public class ApplicantModelDto
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryofOrigin { get; set; }
        public string EMailAddress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
}
