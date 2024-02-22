using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
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

        Applicant applicant = _mapper.Map<Applicant>(request);
        await _repository.AddAsync(applicant);

        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response, "Ekleme Başarılı");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
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
        Applicant applicant = await _repository.GetAsync(x => x.Id == id);

        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
        return new SuccessDataResult<GetByIdApplicantResponse>(response, "GetById İşlemi Başarılı");
    }
    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _repository.UpdateAsync(applicant);


        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
        return new SuccessDataResult<UpdateApplicantResponse>(response, "Update İşlemi Başarılı");
    }

}







