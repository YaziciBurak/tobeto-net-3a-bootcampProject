using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class BlacklistBusinessRules : BaseBusinessRules
{
    private readonly IBlackListRepository _repository;

    public BlacklistBusinessRules(IBlackListRepository repository)
    {

        _repository = repository;
    }
    public async Task CheckIfIdNotExists(int blacklistId)
    {
        var isExists = await _repository.GetAsync(blacklist => blacklist.Id == blacklistId);
        if (isExists is null) throw new BusinessException(BlackListMessages.BlackListIdExist);

    }
}
