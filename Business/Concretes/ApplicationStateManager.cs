using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
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

    public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IMapper mapper)
    {
        _repository = applicationStateRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
    {
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _repository.AddAsync(applicationState);

            CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(response, "Ekleme Başarılı");
        }
    }

    public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        ApplicationState applicationState = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(applicationState);
        return new SuccessResult("Silme Başarılı");
    }

    public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAll()
    {
        List<ApplicationState> applicationState = await _repository.GetAllAsync();

        List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationState);
        return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, "Listeleme Başarılı");
    }

    public async Task<IDataResult<GetByIdApplicationStateResponse>> GetById(int id)
    {
        await CheckIfIdNotExists(id);
        ApplicationState applicationState = await _repository.GetAsync(x => x.Id == id);

        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
        return new SuccessDataResult<GetByIdApplicationStateResponse>(response, "GetById İşlemi Başarılı");
    }

    public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        await _repository.UpdateAsync(applicationState);
        UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
        return new SuccessDataResult<UpdateApplicationStateResponse>(response, "Update İşlemi Başarılı");
    }
    private async Task CheckIfIdNotExists(int applicationStateId)
    {
        var isExists = await _repository.GetAsync(applicationState => applicationState.Id == applicationStateId);
        if (isExists is null) throw new BusinessException("Id not exists");

    }
}
