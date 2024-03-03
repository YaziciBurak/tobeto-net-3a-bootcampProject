using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Business.Rules;
using Core.DataAccess;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _repository;
    private readonly IMapper _mapper;
    private readonly ApplicationBusinessRules _rules;

    public ApplicationManager(IApplicationRepository repository, IMapper mapper, ApplicationBusinessRules applicationBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _rules = applicationBusinessRules; 
    }

    public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
    {
        await _rules.CheckIfBlacklist(request.ApplicantId);
        Application application = _mapper.Map<Application>(request);
        await _repository.AddAsync(application);
        CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
        return new SuccessDataResult<CreateApplicationResponse>(response, ApplicationMessages.ApplicationAdded);
    }

    public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Application application = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(application);
        return new SuccessResult(ApplicationMessages.ApplicationDeleted);
    }

    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAll()
    {
      
        List<Application> applications = await _repository.GetAllAsync
          (include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, ApplicationMessages.ApplicationGetAll);
    }

    public async Task<IDataResult<GetByIdApplicationResponse>> GetById(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        Application application = await _repository.GetAsync(x => x.Id == id,
            include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));

        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
        return new SuccessDataResult<GetByIdApplicationResponse>(response, ApplicationMessages.ApplicationGetById);
    }

    public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Application application = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, application);
        UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
        return new SuccessDataResult<UpdateApplicationResponse>(response, ApplicationMessages.ApplicationUpdated);
    }
}

