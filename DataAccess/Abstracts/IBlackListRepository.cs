using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBlackListRepository : IAsyncRepository<BlackList, int>, IRepository<BlackList, int>
{
    Task<bool> IsApplicantBlacklistedAsync(int applicantId);
}
