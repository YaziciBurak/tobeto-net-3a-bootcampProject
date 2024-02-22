using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _repository;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        await _repository.AddAsync(application);

        CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
        return new SuccessDataResult<CreateApplicationResponse>(response, "Ekleme Başarılı");
    }

    public async Task<IDataResult<DeleteApplicationResponse>> DeleteAsync(DeleteApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        await _repository.DeleteAsync(application);

        DeleteApplicationResponse response = _mapper.Map<DeleteApplicationResponse>(application);
        return new SuccessDataResult<DeleteApplicationResponse>(response, "Silme Başarılı");
    }

    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAll()
    {
        // KONTROL EDİLECEK
        List<Application> applications = await _repository.GetAllAsync
          (include: x => x.Include(x => x.Applicant).Include(x => x.ApplicationState).Include(x => x.Bootcamp));
        List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, "Listeleme Başarılı");
    }

    public async Task<IDataResult<GetByIdApplicationResponse>> GetById(int id)
    {
        // KONTROL EDİLECEK

        Application application = await _repository.GetAsync(x => x.Id == id);

        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
        return new SuccessDataResult<GetByIdApplicationResponse>(response, "GetById İşlemi Başarılı");
    }

    public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
    {
        // KONTROL EDİLECEK
        Application application = await _repository.GetAsync(x => x.Id == request.UserId);


        UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(request);
        return new SuccessDataResult<UpdateApplicationResponse>(response, "Update İşlemi Başarılı");
    }
}

