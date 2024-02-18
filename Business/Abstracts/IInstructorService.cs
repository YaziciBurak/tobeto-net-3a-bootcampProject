using Business.Requests.Applicants;
using Business.Requests.Instructors;
using Business.Responses.Instructors;

namespace Business.Abstracts;

public interface IInstructorService
{
    Task<List<GetAllnstructorResponse>> GetAll();
    Task<GetByIdInstructorResponse> GetById(int id);
    Task<DeleteInstructorResponse> DeleteAsync (DeleteInstructorRequest request);
    Task<UpdateInstructorResponse> UpdateAsync (UpdateInstructorRequest request);
    Task<CreateInstructorResponse> AddAsync (CreateInstructorRequest request);
}
