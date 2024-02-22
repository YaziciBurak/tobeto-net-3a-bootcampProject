using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Microsoft.AspNetCore.Http;
using results = Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Core.Utilities.Results;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _employeeService.GetById(id));
        }

        [HttpPost]
        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            return await _employeeService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<results.IResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            return await _employeeService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            return await _employeeService.UpdateAsync(request);
        }
    }
}