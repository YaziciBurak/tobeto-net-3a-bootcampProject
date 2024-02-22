using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrates;

namespace DataAccess.Repositories;

public class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
{
    protected readonly BaseDbContext _baseDbContext;
    public UserRepository (BaseDbContext baseDbContext) : base (baseDbContext)
    {
        _baseDbContext = baseDbContext;
    }
}
