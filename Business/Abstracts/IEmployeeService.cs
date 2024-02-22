using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IEmployeeService
{
    Task<IDataResult<List<GetAllEmployeeResponse>>> GetAll();
    Task<IDataResult<GetByIdEmployeeResponse>> GetById(int id);
    Task<IResult> DeleteAsync(DeleteEmployeeRequest request);
    Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);
    Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request);

}