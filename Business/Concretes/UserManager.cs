using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using DataAccess.Abstracts;
using Entities.Concrates;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse> Addsync(CreateUserRequest request)
    {
        User user = new User();
        user.UserName = request.UserName;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Password = request.Password;
        user.DateOfBirth = request.DateOfBirth;
        user.NationalIdentity = request.NationalIdentity;
        await _userRepository.Add(user);

        CreateUserResponse response = new CreateUserResponse();
        response.UserName = user.UserName;
        response.FirstName = user.FirstName;
        response.LastName = user.LastName;
        response.Email = user.Email;
        response.Password = user.Password;
        response.DateOfBirth = user.DateOfBirth;
        response.NationalIdentity = user.NationalIdentity;
        response.CreatedDate = user.CreatedDate;
        return response;
    }

    public async Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest request)
    {
        User user = new User();
        user.Id = request.Id;
        user.UserName = request.UserName;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Password = request.Password;
        user.DateOfBirth = request.DateOfBirth;
        user.NationalIdentity = request.NationalIdentity;
        await _userRepository.Delete(user);

        DeleteUserResponse response = new DeleteUserResponse();
        response.UserName = user.UserName;
        response.FirstName = user.FirstName;
        response.LastName = user.LastName;
        response.DateOfBirth = user.DateOfBirth;
        response.NationalIdentity = user.NationalIdentity;
        response.Email = user.Email;
        response.Password = user.Password;
        response.DeletedDate = user.DeletedDate;
        return response;
    }

    public async Task<List<GetAllUserResponse>> GetAll()
    {
        List<GetAllUserResponse> users = new List<GetAllUserResponse>();
        foreach (var user in await _userRepository.GetAll())
        {
            GetAllUserResponse response = new GetAllUserResponse();
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.Email = user.Email;
            response.Password = user.Password;
            response.DeletedDate = user.DeletedDate;
            response.UpdatedDate = user.UpdatedDate;
            response.CreatedDate = user.CreatedDate;
            response.DateOfBirth = user.DateOfBirth;
            response.NationalIdentity = user.NationalIdentity;
            users.Add(response);
        }
        return users;
    }

    public async Task<GetByIdUserResponse> GetById(int id)
    {
        GetByIdUserResponse response = new GetByIdUserResponse();
        User user = await _userRepository.Get(u => u.Id == id);
        response.UserName = user.UserName;
        response.FirstName = user.FirstName;
        response.LastName = user.LastName;
        response.Email = user.Email;
        response.Password = user.Password;
        response.DeletedDate = user.DeletedDate;
        response.UpdatedDate = user.UpdatedDate;
        response.CreatedDate = user.CreatedDate;
        response.DateOfBirth = user.DateOfBirth;
        response.NationalIdentity = user.NationalIdentity;
        return response;
    }

    public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request)
    {
        User user = await _userRepository.Get(u => u.Id == request.Id);
        user.Id = request.Id;
        user.UserName = request.UserName;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.DateOfBirth = request.DateOfBirth;
        user.NationalIdentity = request.NationalIdentity;
        user.Email = request.Email;
        user.Password = request.Password;
        await _userRepository.Update(user);

        UpdateUserResponse response = new UpdateUserResponse();
        response.UserName = user.UserName;
        response.FirstName = user.FirstName;
        response.LastName = user.LastName;
        response.DateOfBirth = user.DateOfBirth;
        response.NationalIdentity = user.NationalIdentity;
        response.Email = user.Email;
        response.Password = user.Password;
        response.UpdatedDate = user.UpdatedDate;
        return response;
    }
}
