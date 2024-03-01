using Business.Abstracts;
using Core.CrossCuttingConcerns;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Repositories;

namespace Business.Rules;

public class ApplicationBusinessRules : BaseBusinessRules
{
    private readonly IApplicationRepository _repository;
    private IBlackListService _blacklistService;

    public ApplicationBusinessRules(IApplicationRepository repository, IBlackListService blacklistService)
    {
        _repository = repository;
        _blacklistService = blacklistService;
    }

    public async Task CheckIfIdNotExists(int applicationId)
    {
        var isExists = await _repository.GetAsync(application => application.Id == applicationId);
        if (isExists is null) throw new BusinessException("Application Id is not exists");

    }

    public async Task CheckIfBlacklist(int id)
    {
        var isBlacklisted = await _blacklistService.GetByApplicantId(id);
        if (isBlacklisted is not null) throw new BusinessException("This applicant cannot create an application because they are blacklisted.");

    }

}
