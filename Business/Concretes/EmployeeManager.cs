using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrates;

namespace Business.Concretes;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;
    private readonly EmployeeBusinessRules _rules;

    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules)
    {
        _repository = employeeRepository;
        _mapper = mapper;
        _rules = employeeBusinessRules;
    }
    public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
    {
        await _rules.CheckIfEmployeeNotExists(request.UserName, request.NationalIdentity);
        Employee employee = _mapper.Map<Employee>(request);
        await _repository.AddAsync(employee);
        CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);
        return new SuccessDataResult<CreateEmployeeResponse>(response, EmployeeMessages.EmployeeAdded);
    }
    public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Employee employee = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(employee);
        return new SuccessResult(EmployeeMessages.EmployeeDeleted);
    }
    public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAll()
    {
        List<Employee> employee = await _repository.GetAllAsync();
        List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employee);
        return new SuccessDataResult<List<GetAllEmployeeResponse>>(responses, EmployeeMessages.EmployeeGetAll);
    }
    public async Task<IDataResult<GetByIdEmployeeResponse>> GetById(int id)
    {
        await _rules.CheckIfIdNotExists(id);
        Employee employee= await _repository.GetAsync(x => x.Id == id);
        GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(employee);
        return new SuccessDataResult<GetByIdEmployeeResponse>(response, EmployeeMessages.EmployeeGetById);
    }
    public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
    {
        await _rules.CheckIfIdNotExists(request.Id);
        Employee employee = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request,employee);
        await _repository.UpdateAsync(employee);
        UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(employee);
        return new SuccessDataResult<UpdateEmployeeResponse>(response, EmployeeMessages.EmployeeUpdated);
    }
}
