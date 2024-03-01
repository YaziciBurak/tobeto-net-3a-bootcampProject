using Core.CrossCuttingConcerns;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _repository;
    public UserBusinessRules(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task CheckIfIdNotExists(int userId)
    {
        var isExists = await _repository.GetAsync(x => x.Id == userId);
        if (isExists is null) throw new BusinessException("User Id is not exists");
    }
}