using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class BootcampStateBusinessRules : BaseBusinessRules
{
    private readonly IBootcampStateRepository _repository;
    public BootcampStateBusinessRules(IBootcampStateRepository repository)
    {
        _repository = repository;
    }
    public async Task CheckIfBootcampStateNameExists(string bootcampStateName)
    {
        var isExits = await _repository.GetAsync(x=>x.Name == bootcampStateName);
        if (isExits is not null) throw new BusinessException(BootcampMessages.BootcampNameExist);
    }
    public async Task CheckIfIdNotExists(int bootcampStateId)
    {
        var isExists = await _repository.GetAsync(bootcampState => bootcampState.Id == bootcampStateId);
        if (isExists is null) throw new BusinessException(BootcampStateMessages.BootcampStateNotExist);
    }
}
