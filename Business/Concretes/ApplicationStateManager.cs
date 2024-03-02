using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Business.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
    {
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _repository.AddAsync(applicationState);
            CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(response, ApplicationStateManagerMessages.ApplicationStateManagerAdded);
        }
    }
    public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        ApplicationState applicationState = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(applicationState);
        return new SuccessResult(ApplicationStateManagerMessages.ApplicationStateManagerDeleted);
    }
    public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAll()
    {
        List<ApplicationState> applicationState = await _repository.GetAllAsync();

        List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationState);
        return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, ApplicationStateManagerMessages.ApplicationStateManagerGetAll);
    }
    public async Task<IDataResult<GetByIdApplicationStateResponse>> GetById(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        ApplicationState applicationState = await _repository.GetAsync(x => x.Id == id);

        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
        return new SuccessDataResult<GetByIdApplicationStateResponse>(response, ApplicationStateManagerMessages.ApplicationStateManagerGetById);
    }
    public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        ApplicationState applicationState = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, applicationState);
        UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
        return new SuccessDataResult<UpdateApplicationStateResponse>(response, ApplicationStateManagerMessages.ApplicationStateManagerUpdated);
    }
}
