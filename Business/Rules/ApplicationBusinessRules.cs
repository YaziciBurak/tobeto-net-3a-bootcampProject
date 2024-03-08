using Business.Abstracts;
using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;

namespace Business.Rules;

public class ApplicationBusinessRules : BaseBusinessRules
{
    private readonly IApplicationRepository _repository;
    private readonly IBlackListService _blacklistService;
    private readonly ApplicantBusinessRules _applicantRules;
    private readonly BootcampBusinessRules _bootcampRules;
    private readonly ApplicationStateBusinessRules _applicationStateRules;
    public ApplicationBusinessRules(IApplicationRepository repository, IBlackListService blacklistService, ApplicantBusinessRules applicantRules, BootcampBusinessRules bootcampRules, ApplicationStateBusinessRules applicationStateRules)
    {
        _repository = repository;
        _blacklistService = blacklistService;
        _applicantRules = applicantRules;
        _bootcampRules = bootcampRules;
        _applicationStateRules = applicationStateRules;
    }
    public async Task CheckIfIdNotExists(int applicationId)
    {
        var isExists = await _repository.GetAsync(application => application.Id == applicationId);
        if (isExists is null) throw new BusinessException(ApplicationMessages.ApplicationIdNotExist);
    }
    public async Task CheckIfBlacklist(int applicantId)
    {
        var applicant = await _blacklistService.ApplicantBlacklistAsync(applicantId);
        if (applicant.Data is not null)throw new BusinessException(ApplicationMessages.ApplicantBlackList);
    }
    public async Task CheckIfApplicantNotExists(int applicantId)
    {
        await _applicantRules.CheckIfIdNotExists(applicantId);
    }
    public async Task CheckIfBootcampNotExists(int bootcampId)
    {
        await _bootcampRules.CheckIfIdNotExists(bootcampId);
    }
    public async Task CheckIfApplicationStateNotExist(int applicationStateId)
    {
        await _applicationStateRules.CheckIfIdNotExists(applicationStateId);
    }
    public async Task CheckIfApplicantBootcampNotExists(int applicantId, int bootcampId)
    {
        var isExists = await _repository.GetAsync(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
        if (isExists is not null) throw new BusinessException(ApplicationMessages.ApplicantBootcampExist);
    }
}
