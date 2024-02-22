using Business.Requests.Applicants;
using Business.Requests.Applications;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicationService
{
    Task<IDataResult<List<GetAllApplicationResponse>>> GetAll();
    Task<IDataResult<GetByIdApplicationResponse>> GetById(int id);
    Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request);
    Task<IDataResult<DeleteApplicationResponse>> DeleteAsync(DeleteApplicationRequest request);
    Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
}
