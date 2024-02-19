using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
using DataAccess.Abstracts;
using Entities.Concrates;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeManager(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request)
    {
        Employee employee = new Employee();
        employee.UserName = request.UserName;
        employee.Password = request.Password;
        employee.Email = request.Email;
        employee.DateOfBirth = request.DateOfBirth;
        employee.NationalIdentity = request.NationalIdentity;
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Position = request.Position;
        await _employeeRepository.AddAsync(employee);

        CreateEmployeeResponse response = new CreateEmployeeResponse();
        response.UserId = employee.Id;
        response.Position = employee.Position;
        return response;

    }

    public async Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request)
    {
        Employee employee = new Employee();
        employee.Id = request.UserId;
        await _employeeRepository.DeleteAsync(employee);

        DeleteEmployeeResponse response = new DeleteEmployeeResponse();
        response.UserId = employee.Id;
        return response;
    }

    public async Task<List<GetAllEmployeeResponse>> GetAll()
    {
        List<GetAllEmployeeResponse> employees = new List<GetAllEmployeeResponse>();
        foreach (var employee in await _employeeRepository.GetAllAsync())
        {
            GetAllEmployeeResponse response = new GetAllEmployeeResponse();
            response.UserId = employee.Id;
            response.Position = employee.Position;
            employees.Add(response);
        }
        return employees;
    }

    public async Task<GetByIdEmployeeResponse> GetById(int id)
    {
        GetByIdEmployeeResponse response = new GetByIdEmployeeResponse();
        Employee employee = await _employeeRepository.GetAsync(e => e.Id == id);
        response.UserId = employee.Id;
        response.Position = employee.Position;
        return response;

    }

    public async Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
    {
        Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.UserId);
        employee.Id = request.UserId;
        employee.UserName = request.UserName;
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.DateOfBirth = request.DateOfBirth;
        employee.Email = request.Email;
        employee.Password = request.Password;
        employee.Position = request.Position;
        employee.NationalIdentity = request.NationalIdentity;
        await _employeeRepository.UpdateAsync(employee);

        UpdateEmployeeResponse response = new UpdateEmployeeResponse();
        response.UserId = employee.Id;
        response.Position = employee.Position;
        response.NationalIdentity = employee.NationalIdentity;
        response.Email = employee.Email;
        response.Password = employee.Password;
        response.DateOfBirth = employee.DateOfBirth;
        response.UserName = employee.UserName;
        response.LastName = employee.LastName;
        response.FirstName = employee.FirstName;
        return response;
    }
}
