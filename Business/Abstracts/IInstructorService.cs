using Business.Requests.Applicants;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IInstructorService
{
    Task<IDataResult<List<GetAllnstructorResponse>>> GetAll();
    Task<IDataResult<GetByIdInstructorResponse>> GetById(int id);
    Task<IDataResult<DeleteInstructorResponse>> DeleteAsync (DeleteInstructorRequest request);
    Task<IDataResult<UpdateInstructorResponse>> UpdateAsync (UpdateInstructorRequest request);
    Task<IDataResult<CreateInstructorResponse>> AddAsync (CreateInstructorRequest request);
}
