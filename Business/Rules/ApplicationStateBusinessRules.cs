using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class ApplicationStateBusinessRules : BaseBusinessRules
{
    private IApplicationStateRepository _repository;

    public ApplicationStateBusinessRules(IApplicationStateRepository repository)
    {
        _repository = repository;
    }
    public async Task CheckIfApplicationStateNameExists(string applicationStateName)
    {
        var isExists = await _repository.GetAsync(x=> x.Name == applicationStateName);
        if (isExists is not null) throw new BusinessException(ApplicationStateManagerMessages.ApplicationStateNameExist);
    }
    public async Task CheckIfIdNotExists(int id)
    {
        var isExists = await _repository.GetAsync(x => x.Id == id);
        if (isExists is null) throw new BusinessException(ApplicationStateManagerMessages.ApplicationStateIdNotExist);

    }
}
