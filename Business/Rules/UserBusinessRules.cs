using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;
using DataAccess.Repositories;

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
        if (isExists is null) throw new BusinessException(UserMessages.UserNotExist);
    }
    public async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _repository.GetAsync(u => u.Email == email);
        if (user is not null) throw new BusinessException("User mail already exists");
    }
    public async Task UserEmailShouldBeExists(string email)
    {
        User? user = await _repository.GetAsync(u => u.Email == email);
        if (user is null) throw new BusinessException("Email or Password don't match");
    }
    public Task UserShouldBeExists(User? user)
    {
        if (user is null) throw new BusinessException("Email or Password don't match");
        return Task.CompletedTask;
    }
    public async Task UserPasswordShouldBeMatch(int id, string password)
    {
        User? user = await _repository.GetAsync(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Email or Password don't match");
    }
}