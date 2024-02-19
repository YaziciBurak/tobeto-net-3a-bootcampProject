using Core.DataAccess;
using Entities.Concrates;

namespace DataAccess.Abstracts;

public interface IInstructorRepository : IAsyncRepository<Instructor, int>, IRepository<Instructor, int>
{
}
