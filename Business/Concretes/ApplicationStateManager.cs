using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;

namespace Business.Concretes;

public class ApplicationStateManager : IApplicationStateService
{
    private readonly IApplicationStateRepository _repository;
    private readonly IMapper _mapper;

    public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IMapper mapper)
    {
        _repository = applicationStateRepository;
        _mapper = mapper;
    }

    public Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<GetByIdApplicationStateResponse>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
    {
        throw new NotImplementedException();
    }
}
