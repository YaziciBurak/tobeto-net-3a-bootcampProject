using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using System.Runtime.InteropServices;

namespace Business.Abstracts;

public interface IUserService
{
    Task<IDataResult<List<GetAllUserResponse>>> GetAll();
    Task<IDataResult<GetByIdUserResponse>> GetById(int id);
    Task<DataResult<User>> GetByMail(string email);
}
