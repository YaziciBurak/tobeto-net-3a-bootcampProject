using Core.DataAccess;
using Entities.Concrates;

namespace DataAccess.Abstracts;

public interface IEmployeeRepository : IAsyncRepository<Employee, int>
{
}
