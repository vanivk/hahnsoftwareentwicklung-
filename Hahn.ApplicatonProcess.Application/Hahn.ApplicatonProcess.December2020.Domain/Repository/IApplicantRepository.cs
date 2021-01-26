using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Repository
{
    public interface IApplicantRepository
    {
        Task<int> Create(Model.ApplicantModel applicantModel);

        Task<List<Model.ApplicantModel>> GetAllApplicants();

        Task<Model.ApplicantModel> GetApplicant(int id);

        Task<int> Update(int id, Model.ApplicantModel applicantModel);

        Task<int> Delete(int id);

    }
}
