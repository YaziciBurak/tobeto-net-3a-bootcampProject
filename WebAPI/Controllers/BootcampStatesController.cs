using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Requests.Employees;
using Business.Responses.BootcampStates;
using Business.Responses.Employees;
using Core.Utilities.Results;
using results = Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStatesController : ControllerBase
    {
        private readonly IBootcampStateService _service;

        public BootcampStatesController(IBootcampStateService bootcampState)
        {
            _service = bootcampState;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            return await _service.AddAsync(request);
        }

        [HttpDelete]
        public async Task<results.IResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            return await _service.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            return await _service.UpdateAsync(request);
        }
    }
}
