using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concrates;

namespace DataAccess.Repositories;

public class InstructorRepository : EfRepositoryBase<Instructor, int, BaseDbContext>, IInstructorRepository
{
    public InstructorRepository(BaseDbContext baseDbContext) : base(baseDbContext)
    {

    }
}
