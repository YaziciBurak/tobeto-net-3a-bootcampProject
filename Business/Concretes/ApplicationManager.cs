using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
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
    private readonly IBlackListRepository _blackListRepository;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository repository, IMapper mapper, IBlackListRepository blackListRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _blackListRepository = blackListRepository; 
    }

    public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
    {
        await CheckIfBlacklist(request.ApplicantId);
        Application application = _mapper.Map<Application>(request);
        await _repository.AddAsync(application);

        CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
        return new SuccessDataResult<CreateApplicationResponse>(response, "Ekleme Başarılı");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        Application application = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(application);
        return new SuccessResult("Silme Başarılı");
    }

    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAll()
    {
      
        List<Application> applications = await _repository.GetAllAsync
          (include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, "Listeleme Başarılı");
    }

    public async Task<IDataResult<GetByIdApplicationResponse>> GetById(int id)
    {
        await CheckIfIdNotExists(id);
        Application application = await _repository.GetAsync(x => x.Id == id,
            include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));

        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
        return new SuccessDataResult<GetByIdApplicationResponse>(response, "GetById İşlemi Başarılı");
    }

    public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        Application application = _mapper.Map<Application>(request);
        await _repository.UpdateAsync(application);
        UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
        return new SuccessDataResult<UpdateApplicationResponse>(response, "Update İşlemi Başarılı");
    }

    private async Task CheckIfIdNotExists(int applicationId)
    {
        var isExists = await _repository.GetAsync(application => application.Id == applicationId);
        if (isExists is null) throw new BusinessException("Id not exists");

    }
    private async Task CheckIfBlacklist(int id)
    {
        var isBlacklisted = await _blackListRepository.GetAsync(x => x.ApplicantId == id);
        if (isBlacklisted is not null) throw new BusinessException("Bu başvuru sahibi kara listede olduğu için başvuru oluşturulamaz.");

    }
}

