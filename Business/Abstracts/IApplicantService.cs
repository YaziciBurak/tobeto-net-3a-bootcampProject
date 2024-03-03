using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicantService
{
    Task<IDataResult<List<GetAllApplicantResponse>>> GetAll();
    Task<IDataResult<GetByIdApplicantResponse>> GetById(int id);
    Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request);
    Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);
    Task<IResult> DeleteAsync(DeleteApplicantRequest request);
}
