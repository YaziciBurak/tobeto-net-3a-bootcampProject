using Business.Requests.ApplicationStates;
using Business.Requests.Bootcamps;
using Business.Responses.ApplicationStates;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicationStateService
{
    Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAll();
    Task<IDataResult<GetByIdApplicationStateResponse>> GetById(int id);
    Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
    Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request);
    Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
}
