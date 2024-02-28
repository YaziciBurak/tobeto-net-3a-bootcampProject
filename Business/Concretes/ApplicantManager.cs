using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;

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
        await CheckIfApplicantNotExists(request.UserName, request.NationalIdentity);
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _repository.AddAsync(applicant);

        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response, "Ekleme Başarılı");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        Applicant applicant = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(applicant);
        return new SuccessResult("Silme Başarılı");
    }


    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAll()
    {

        List<Applicant> applicant = await _repository.GetAllAsync();
        List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicant);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, "Listeleme Başarılı");
    }


    public async Task<IDataResult<GetByIdApplicantResponse>> GetById(int id)
    {
        await CheckIfIdNotExists(id);
        Applicant applicant = await _repository.GetAsync(x => x.Id == id);

        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
        return new SuccessDataResult<GetByIdApplicantResponse>(response, "GetById İşlemi Başarılı");
    }
    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _repository.UpdateAsync(applicant);

        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
        return new SuccessDataResult<UpdateApplicantResponse>(response, "Update İşlemi Başarılı");
    }
    private async Task CheckIfIdNotExists(int id)
    {
        var isExists = await _repository.GetAsync(applicant => applicant.Id == id);
        if (isExists is null) throw new BusinessException("Id not exists");

    }

    private async Task CheckIfApplicantNotExists(string userName, string nationalIdentity)
    {
        var isExists = await _repository.GetAsync(applicant => applicant.UserName == userName || applicant.NationalIdentity == nationalIdentity);
        if (isExists is not null) throw new BusinessException("UserName or National Identity is already exists");

    }
}







