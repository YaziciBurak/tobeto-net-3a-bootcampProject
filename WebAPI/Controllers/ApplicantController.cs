using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using results = Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Core.Utilities.Results;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _applicantService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _applicantService.GetById(id));
        }

        [HttpPost]
        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            return await _applicantService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<results.IResult> DeleteAsync (DeleteApplicantRequest request)
        {
            return  await _applicantService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            return await _applicantService.UpdateAsync(request);
        }

    }
}
