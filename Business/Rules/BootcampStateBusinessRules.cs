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
    public async Task CheckIfIdNotExists(int bootcampStateId)
    {
        var isExists = await _repository.GetAsync(bootcampState => bootcampState.Id == bootcampStateId);
        if (isExists is null) throw new BusinessException(BootcampStateMessages.BootcampStateExist);
    }
}
