using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;

namespace DataAccess.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}
