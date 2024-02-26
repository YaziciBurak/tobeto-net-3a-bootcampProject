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
    public class ApplicantsController : BaseController
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _applicantService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return HandleDataResult(await _applicantService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateApplicantRequest request)
        {
            return HandleDataResult(await _applicantService.AddAsync(request));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync ([FromRoute] DeleteApplicantRequest request)
        {
            return HandleResult(await _applicantService.DeleteAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateApplicantRequest request)
        {
            return HandleDataResult(await _applicantService.UpdateAsync(request));
        }

    }
}
