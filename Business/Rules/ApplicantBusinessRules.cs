using Business.Abstracts;
using Core.CrossCuttingConcerns;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class ApplicantBusinessRules : BaseBusinessRules
{
    private readonly IApplicantRepository _repository;
    public ApplicantBusinessRules(IApplicantRepository repository)
    {
        _repository = repository;
    }

    public async Task CheckIfIdNotExists(int applicantId)
    {
        var isExists = await _repository.GetAsync(applicant => applicant.Id == applicantId);
        if (isExists is null) throw new BusinessException("Applicant Id is not exists");

    }

    public async Task CheckIfApplicantNotExists(string userName, string nationalIdentity)
    {
        var isExists = await _repository.GetAsync(applicant => applicant.UserName == userName || applicant.NationalIdentity == nationalIdentity);
        if (isExists is not null) throw new BusinessException("UserName or National Identity is already exists");

    }
}
