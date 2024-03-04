using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class InstructorBusinessRules : BaseBusinessRules
{
    private readonly IInstructorRepository _repository;
    public InstructorBusinessRules(IInstructorRepository repository)
    {
        _repository = repository;
    }
    public async Task CheckIfIdNotExists(int instructorId)
    {
        var isExists = await _repository.GetAsync(x => x.Id == instructorId);
        if (isExists is null) throw new BusinessException(InstructorMessages.InstructorNotExist);
    }
    public async Task CheckIfInstructorNotExists(string userName, string nationalIdentity)
    {
        var isExists = await _repository.GetAsync(x => x.UserName == userName || x.NationalIdentity == nationalIdentity);
        if (isExists is not null) throw new BusinessException(InstructorMessages.InstructorUsernameNotExist); 
    }
}
