using Business.Requests.Users;
using Business.Responses.Users;
using System.Runtime.InteropServices;

namespace Business.Abstracts;

public interface IUserService
{
    Task<List<GetAllUserResponse>> GetAll();
    Task<GetByIdUserResponse> GetById(int id);
    Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request);
    Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest request);
    Task<CreateUserResponse> Addsync(CreateUserRequest request);
}
