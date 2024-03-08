using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;

public class BootcampBusinessRules : BaseBusinessRules
{
    private readonly IBootcampRepository _repository;

    public BootcampBusinessRules(IBootcampRepository repository)
    {
        _repository = repository;
    }
    public async Task CheckIfIdNotExists(int bootcampId)
    {
        var isExists = await _repository.GetAsync(bootcamp => bootcamp.Id == bootcampId);
        if (isExists is null) throw new BusinessException(BootcampMessages.BootcampIdNotExist);
    }

    public async Task CheckIfBootcampExists(string bootcampName)
    {
        var isExists = await _repository.GetAsync(bootcamp => bootcamp.Name == bootcampName);
        if (isExists is not null) throw new BusinessException(BootcampMessages.BootcampExist);
    }
        
    public async Task CheckIfOtherIdNotExists(int bootcampStateId, int instructorId)
    {
        var isExists = await _repository.GetAsync(x => x.BootcampStateId == bootcampStateId || x.InstructorId == instructorId);
        if (isExists is null) throw new BusinessException(BootcampMessages.BootcampNotExist);

    }

}
