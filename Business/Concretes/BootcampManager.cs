using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Business.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _repository;
    private readonly IMapper _mapper;
    private readonly BootcampBusinessRules _rules;
    public BootcampManager(IBootcampRepository repository, IMapper mapper, BootcampBusinessRules bootcampBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _rules = bootcampBusinessRules;
    }

    public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
    {
        await _rules.CheckIfOtherIdNotExists(request.BootcampStateId, request.InstructorId);
        Bootcamp bootcamp = await _repository.GetAsync(x => x.BootcampStateId == request.BootcampStateId || x.InstructorId == request.InstructorId);
        bootcamp = _mapper.Map<Bootcamp>(request);
        await _repository.AddAsync(bootcamp);
        CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreateBootcampResponse>(response, BootcampMessages.BootcampAdded);
    }

    public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Bootcamp bootcamp = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(bootcamp);
        return new SuccessResult(BootcampMessages.BootcampDeleted);
    }

    public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAll()
    {
        List<Bootcamp> bootcamps = await _repository.GetAllAsync
          (include: x => x.Include(x => x.BootcampState).Include(x => x.Instructor));
        List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(responses, BootcampMessages.BootcampGetAll);
    }

    public async Task<IDataResult<GetByIdBootcampResponse>> GetById(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        Bootcamp bootcamp = await _repository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.BootcampState).Include(x => x.Instructor));

        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);
        return new SuccessDataResult<GetByIdBootcampResponse>(response, BootcampMessages.BootcampGetById);
    }

    public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Bootcamp bootcamp = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, bootcamp);
        await _repository.UpdateAsync(bootcamp);
        UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(bootcamp);
        return new SuccessDataResult<UpdateBootcampResponse>(response, BootcampMessages.BootcampUpdated);
    }
}
