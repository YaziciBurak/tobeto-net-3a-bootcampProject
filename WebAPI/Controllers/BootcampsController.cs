using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using results = Core.Utilities.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampsController : ControllerBase
    {
        private readonly IBootcampService _service;

        public BootcampsController(IBootcampService bootcamp)
        {
            _service = bootcamp;
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
        public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
        {
            return await _service.AddAsync(request);
        }

        [HttpDelete]
        public async Task<results.IResult> DeleteAsync(DeleteBootcampRequest request)
        {
            return await _service.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
        {
            return await _service.UpdateAsync(request);
        }
    }
}
