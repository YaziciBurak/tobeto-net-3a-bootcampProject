using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
using System.Runtime.InteropServices;

namespace Business.Abstracts;

public interface IUserService
{
    
    Task<IDataResult<List<GetAllUserResponse>>> GetAll();
    Task<IDataResult<GetByIdUserResponse>> GetById(int id);

}
