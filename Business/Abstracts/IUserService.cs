using Business.Requests.Users;
using Business.Responses.Users;
using System.Runtime.InteropServices;

namespace Business.Abstracts;

public interface IUserService
{
    //Dönüşte veri dönmüyorsa result -- dönüyosa dataresult
    Task<List<GetAllUserResponse>> GetAll();
    Task<GetByIdUserResponse> GetById(int id);

}
