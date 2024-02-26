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
    public class BootcampsController : BaseController
    {
        private readonly IBootcampService _service;

        public BootcampsController(IBootcampService bootcamp)
        {
            _service = bootcamp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return HandleDataResult(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBootcampRequest request)
        {
            return HandleDataResult(await _service.AddAsync(request));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteBootcampRequest request)
        {
            return HandleResult(await _service.DeleteAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBootcampRequest request)
        {
            return HandleDataResult(await _service.UpdateAsync(request));
        }
    }
}
