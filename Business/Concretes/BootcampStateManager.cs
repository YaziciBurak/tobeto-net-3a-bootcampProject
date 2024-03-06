using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Business.Rules;
using Core.Aspects.AutoFac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _repository;
    private readonly IMapper _mapper;
    private readonly BootcampStateBusinessRules _rules;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper, BootcampStateBusinessRules bootcampStateBusinessRules)
    {
        _repository = bootcampStateRepository;
        _mapper = mapper;
        _rules = bootcampStateBusinessRules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _repository.AddAsync(bootcampState);
        CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<CreateBootcampStateResponse>(response, BootcampStateMessages.BootcampStateAdded);
    }
    public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        BootcampState bootcampState = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(bootcampState);
        return new SuccessResult(BootcampStateMessages.BootcampStateDeleted);
    }
    public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAll()
    {
        List<BootcampState> bootcampState = await _repository.GetAllAsync();
        List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampState);
        return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses, BootcampStateMessages.BootcampStateGetAll);
    }
    public async Task<IDataResult<GetByIdBootcampStateResponse>> GetById(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        BootcampState bootcampState = await _repository.GetAsync(x => x.Id == id);
        GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<GetByIdBootcampStateResponse>(response, BootcampStateMessages.BootcampStateGetById);
    }
    public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        BootcampState bootcampState = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, bootcampState);
        await _repository.UpdateAsync(bootcampState);
        UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<UpdateBootcampStateResponse>(response, BootcampStateMessages.BootcampStateUpdated);
    }
}
