using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Business.Responses.Applications;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concrates;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _repository;
    private readonly IMapper _mapper;

    public ApplicantManager(IApplicantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
    {

        Applicant applicant = _mapper.Map<Applicant>(request);
        await _repository.AddAsync(applicant);

        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response, "Ekleme Başarılı");
    }

    public async Task<IDataResult<DeleteApplicantResponse>> DeleteAsync(DeleteApplicantRequest request)
    {
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _repository.DeleteAsync(applicant);

        DeleteApplicantResponse response = _mapper.Map<DeleteApplicantResponse>(applicant);
        return new SuccessDataResult<DeleteApplicantResponse>(response, "Silme Başarılı");
    }


    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAll()
    {
        // KONTROL EDİLECEK
        List<Applicant> applicant = await _repository.GetAllAsync
            (include: x => x.Include(x => x.Applications));
        List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicant);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, "Listeleme Başarılı");
    }


    public async Task<IDataResult<GetByIdApplicantResponse>> GetById(int id)
    {
        // KONTROL EDİLECEK
        Applicant applicant = await _repository.GetAsync(x => x.Id == id);

        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
        return new SuccessDataResult<GetByIdApplicantResponse>(response, "GetById İşlemi Başarılı");
    }
    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        // KONTROL EDİLECEK
        Applicant applicant = await _repository.GetAsync(x => x.Id == request.UserId);


        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(request);
        return new SuccessDataResult<UpdateApplicantResponse>(response, "Update İşlemi Başarılı");
    }

}







