using Core.DataAccess;
using Entities.Concretes;
using Entities.Entity;

namespace DataAccess.Abstracts;

public interface IApplicationStateRepository : IAsyncRepository<ApplicationState, int>, IRepository<ApplicationState, int>
{
}
