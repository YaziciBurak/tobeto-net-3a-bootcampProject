using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Business.Rules;
using Core.Aspects.AutoFac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
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
    private readonly ApplicantBusinessRules _rules;

    public ApplicantManager(IApplicantRepository repository, IMapper mapper, ApplicantBusinessRules applicantBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _rules = applicantBusinessRules;
    }
    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
    {
        await _rules.CheckIfApplicantNotExists(request.UserName, request.NationalIdentity);
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _repository.AddAsync(applicant);
        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response, ApplicantMessages.ApplicantAdded);
    }

    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Applicant applicant = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(applicant);
        return new SuccessResult(ApplicantMessages.ApplicantDeleted);
    }


    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAll()
    {
        List<Applicant> applicant = await _repository.GetAllAsync();
        List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicant);
        return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, ApplicantMessages.ApplicantGetAll);
    }
    public async Task<IDataResult<GetByIdApplicantResponse>> GetById(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        Applicant applicant = await _repository.GetAsync(x => x.Id == id);
        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
        return new SuccessDataResult<GetByIdApplicantResponse>(response, ApplicantMessages.ApplicantGetById);
    }
    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Applicant applicant = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, applicant);
        await _repository.UpdateAsync(applicant);
        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
        return new SuccessDataResult<UpdateApplicantResponse>(response, ApplicantMessages.ApplicantUpdated);
    }
}







