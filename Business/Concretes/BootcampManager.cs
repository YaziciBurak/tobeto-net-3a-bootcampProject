using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using DataAccess.Abstracts;

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

    public Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<DeleteBootcampResponse>> DeleteAsync(DeleteBootcampRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<List<GetAllBootcampResponse>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<GetByIdBootcampResponse>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
    {
        throw new NotImplementedException();
    }
}
