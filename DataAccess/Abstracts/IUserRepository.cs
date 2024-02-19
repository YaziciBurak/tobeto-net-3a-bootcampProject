using Core.DataAccess;
using Entities.Concrates;

namespace DataAccess.Abstracts;

public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int>
{
}
