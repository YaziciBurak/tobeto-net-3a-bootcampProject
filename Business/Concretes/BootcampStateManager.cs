using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;

namespace Business.Concretes;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly IMapper _mapper;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _mapper = mapper;
    }

    public Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<DeleteBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<GetByIdBootcampStateResponse>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        throw new NotImplementedException();
    }
}
