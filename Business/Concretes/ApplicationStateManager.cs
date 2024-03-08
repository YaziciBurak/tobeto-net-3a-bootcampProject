using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Business.Rules;
using Core.Aspects.AutoFac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Entity;

namespace Business.Concretes;

public class ApplicationStateManager : IApplicationStateService
{
    private readonly IApplicationStateRepository _repository;
    private readonly IMapper _mapper;
    private readonly ApplicationStateBusinessRules _rules;

    public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IMapper mapper, ApplicationStateBusinessRules applicationStateBusinessRules)
    {
        _repository = applicationStateRepository;
        _mapper = mapper;
        _rules = applicationStateBusinessRules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
    {
        {
            await _rules.CheckIfApplicationStateNameExists(request.Name);
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _repository.AddAsync(applicationState);
            CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(response, ApplicationStateManagerMessages.ApplicationStateAdded);
        }
    }
    public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        ApplicationState applicationState = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(applicationState);
        return new SuccessResult(ApplicationStateManagerMessages.ApplicationStateDeleted);
    }
    public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAll()
    {
        List<ApplicationState> applicationState = await _repository.GetAllAsync();

        List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationState);
        return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, ApplicationStateManagerMessages.ApplicationStateGetAll);
    }
    public async Task<IDataResult<GetByIdApplicationStateResponse>> GetById(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        ApplicationState applicationState = await _repository.GetAsync(x => x.Id == id);

        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
        return new SuccessDataResult<GetByIdApplicationStateResponse>(response, ApplicationStateManagerMessages.ApplicationStateGetById);
    }
    public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        ApplicationState applicationState = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, applicationState);
        UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
        return new SuccessDataResult<UpdateApplicationStateResponse>(response, ApplicationStateManagerMessages.ApplicationStateUpdated);
    }
}
