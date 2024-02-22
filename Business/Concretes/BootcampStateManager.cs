using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Applicants;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _repository;
    private readonly IMapper _mapper;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
    {
        _repository = bootcampStateRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {     
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _repository.AddAsync(bootcampState);

        CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<CreateBootcampStateResponse>(response, "Ekleme Başarılı");
    }

    public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
    {
        BootcampState bootcampState = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(bootcampState);
        return new SuccessResult("Silme Başarılı");
    }

    public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAll()
    {
        List<BootcampState> bootcampState = await _repository.GetAllAsync();
        List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampState);
        return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses, "Listeleme Başarılı");
    }

    public async Task<IDataResult<GetByIdBootcampStateResponse>> GetById(int id)
    {
        BootcampState bootcampState = await _repository.GetAsync(x => x.Id == id);
        GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<GetByIdBootcampStateResponse>(response, "GetById İşlemi Başarılı");
    }

    public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _repository.UpdateAsync(bootcampState);
        UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
        return new SuccessDataResult<UpdateBootcampStateResponse>(response, "Update İşlemi Başarılı");
    }
}
