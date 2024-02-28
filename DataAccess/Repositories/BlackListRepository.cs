using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class BlackListRepository : EfRepositoryBase<BlackList, int, BaseDbContext>, IBlackListRepository
{
    public BlackListRepository(BaseDbContext context) : base(context)
    {
    }
   
}
