using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBootcampService
{
    Task<IDataResult<List<GetAllBootcampResponse>>> GetAll();
    Task<IDataResult<GetByIdBootcampResponse>> GetById(int id);
    Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request);
    Task<IDataResult<DeleteBootcampResponse>> DeleteAsync(DeleteBootcampRequest request);
    Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request);
}
