using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;
using results = Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _instructorService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _instructorService.GetById(id));
        }

        [HttpPost]
        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            return await _instructorService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<results.IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            return await _instructorService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            return await _instructorService.UpdateAsync(request);
        }
    }
}