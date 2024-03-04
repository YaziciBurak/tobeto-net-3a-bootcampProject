using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _repository;
    public EmployeeBusinessRules(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    public async Task CheckIfIdNotExists(int employeeId)
    {
        var isExists = await _repository.GetAsync(x => x.Id == employeeId);
        if (isExists is null) throw new BusinessException(EmployeeMessages.EmployeeIdNotExist);
    }
    public async Task CheckIfEmployeeNotExists(string userName, string nationalIdentity)
    {
        var isExists = await _repository.GetAsync(x => x.UserName == userName || x.NationalIdentity == nationalIdentity);
        if (isExists is not null) throw new BusinessException(EmployeeMessages.EmployeeExist);
    }
}
