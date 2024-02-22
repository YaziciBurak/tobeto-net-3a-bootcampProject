using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Requests.Bootcamps;
using Business.Responses.ApplicationStates;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using results = Core.Utilities.Results;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatesController : ControllerBase
    {
        private readonly IApplicationStateService _service;

        public ApplicationStatesController(IApplicationStateService applicationState)
        {
            _service = applicationState;
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
        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            return await _service.AddAsync(request);
        }

        [HttpDelete]
        public async Task<results.IResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            return await _service.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            return await _service.UpdateAsync(request);
        }
    }
}
