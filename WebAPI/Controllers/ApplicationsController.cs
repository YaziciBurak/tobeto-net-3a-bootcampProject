using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using results = Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Business.Requests.Applications;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _service;

        public ApplicationsController(IApplicationService application)
        {
            _service = application;
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
        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            return await _service.AddAsync(request);
        }

        [HttpDelete]
        public async Task<results.IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            return await _service.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            return await _service.UpdateAsync(request);
        }
    }
}
