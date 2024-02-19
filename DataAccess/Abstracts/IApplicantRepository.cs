using Core.DataAccess;
using Entities.Concrates;

namespace DataAccess.Abstracts;

public  interface IApplicantRepository : IAsyncRepository<Applicant, int>, IRepository<Applicant, int>
{
}
