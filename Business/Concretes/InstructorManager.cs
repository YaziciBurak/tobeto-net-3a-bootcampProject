using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Business.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;

namespace Business.Concretes;

internal class InstructorManager : IInstructorService
{

    private readonly IInstructorRepository _repository;
    private readonly IMapper _mapper;
    private readonly InstructorBusinessRules _rules;



    public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper,InstructorBusinessRules instructorBusinessRules)
    {
        _repository = instructorRepository;
        _mapper = mapper;
        _rules = instructorBusinessRules;
    }

    public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
    {
        await _rules.CheckIfInstructorNotExists(request.UserName, request.NationalIdentity);
        Instructor instructor = _mapper.Map<Instructor>(request);
        await _repository.AddAsync(instructor);
        CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(instructor);
        return new SuccessDataResult<CreateInstructorResponse>(response, InstructorMessages.InstructorAdded);
    }
    public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Instructor instructor = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(instructor);
        return new SuccessResult(InstructorMessages.InstructorDeleted);
    }
    public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAll()
    {
        List<Instructor> instructors = await _repository.GetAllAsync();
        List<GetAllInstructorResponse> responses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);
        return new SuccessDataResult<List<GetAllInstructorResponse>>(responses, InstructorMessages.InstructorGetAll);
    }
    public async Task<IDataResult<GetByIdInstructorResponse>> GetById(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        Instructor instructor = await _repository.GetAsync(x => x.Id == id);
        GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(instructor);
        return new SuccessDataResult<GetByIdInstructorResponse>(response, InstructorMessages.InstructorGetById);
    }
    public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Instructor instructor = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, instructor);
        await _repository.UpdateAsync(instructor);
        UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(instructor);
        return new SuccessDataResult<UpdateInstructorResponse>(response, InstructorMessages.InstructortUpdated);
    }
}
