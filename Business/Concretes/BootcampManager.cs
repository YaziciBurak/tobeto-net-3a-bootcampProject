using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
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

    public BootcampManager(IBootcampRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
    {
        await CheckIfOtherIdNotExists(request.BootcampStateId, request.InstructorId);
        Bootcamp bootcamp = await _repository.GetAsync(x => x.BootcampStateId == request.BootcampStateId || x.InstructorId == request.InstructorId);
        bootcamp = _mapper.Map<Bootcamp>(request);
        await _repository.AddAsync(bootcamp);

        CreateBootcampResponse response = _mapper.Map<CreateBootcampResponse>(bootcamp);
        return new SuccessDataResult<CreateBootcampResponse>(response, "Ekleme Başarılı");
    }

    public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        Bootcamp bootcamp = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(bootcamp);
        return new SuccessResult("Silme Başarılı");
    }

    public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAll()
    {
        List<Bootcamp> bootcamps = await _repository.GetAllAsync
          (include: x => x.Include(x => x.BootcampState).Include(x => x.Instructor));
        List<GetAllBootcampResponse> responses = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(responses, "Listeleme Başarılı");
    }

    public async Task<IDataResult<GetByIdBootcampResponse>> GetById(int id)
    {
        await CheckIfIdNotExists(id);
        Bootcamp bootcamp = await _repository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.BootcampState).Include(x => x.Instructor));

        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(bootcamp);
        return new SuccessDataResult<GetByIdBootcampResponse>(response, "GetById İşlemi Başarılı");
    }

    public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
    {
        await CheckIfIdNotExists(request.Id);
        Bootcamp bootcamp = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, bootcamp);
        await _repository.UpdateAsync(bootcamp);
        UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(bootcamp);
        return new SuccessDataResult<UpdateBootcampResponse>(response, "Update İşlemi Başarılı");
    }
    private async Task CheckIfIdNotExists(int id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id);
        if (entity is null) throw new BusinessException("Bootcamp not exists");


    }
    private async Task CheckIfOtherIdNotExists(int bootcampStateId, int instructorId)
    {
        var isExists = await _repository.GetAsync(x => x.BootcampStateId == bootcampStateId || x.InstructorId == instructorId);
        if (isExists is null) throw new BusinessException("BootcampState or Instructor is not exists");

    }
}
