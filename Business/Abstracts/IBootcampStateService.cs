using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBootcampStateService
{
    Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAll();
    Task<IDataResult<GetByIdBootcampStateResponse>> GetById(int id);
    Task<IDataResult<CreateBootcampStateResponse>> AddAsync (CreateBootcampStateRequest request);
    Task<IResult> DeleteAsync (DeleteBootcampStateRequest request);
    Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync (UpdateBootcampStateRequest request);
}
