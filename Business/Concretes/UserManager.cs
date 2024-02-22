using AutoMapper;
using Business.Abstracts;
using Business.Responses.Instructors;
using Business.Responses.Users;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrates;
using Entities.Concretes;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<List<GetAllUserResponse>>> GetAll()
    {
        List<User> users = await _userRepository.GetAllAsync();
        List<GetAllUserResponse> responses = _mapper.Map<List<GetAllUserResponse>>(users);
        return new SuccessDataResult<List<GetAllUserResponse>>(responses, "Listeleme Başarılı");
    }


    public async Task<IDataResult<GetByIdUserResponse>> GetById(int id)
    {
        User user = await _userRepository.GetAsync(x => x.Id == id);
        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);
        return new SuccessDataResult<GetByIdUserResponse>(response, "GetById İşlemi Başarılı");
    }


}