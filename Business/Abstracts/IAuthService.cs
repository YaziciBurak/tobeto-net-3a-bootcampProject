using Business.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<DataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
    Task<DataResult<AccessToken>> RegisterApplicant(ApplicantForRegisterDto applicantForRegisterDto);
    Task<DataResult<AccessToken>> RegisterEmployee(EmployeeForRegisterDto employeeForRegisterDto);
    Task<DataResult<AccessToken>> RegisterInstructor(InstructorForRegisterDto instructorForRegisterDto);
    Task<DataResult<AccessToken>> CreateAccessToken(User user);
}
