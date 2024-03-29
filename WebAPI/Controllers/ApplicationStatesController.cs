﻿using Business.Abstracts;
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
    public class ApplicationStatesController : BaseController
    {
        private readonly IApplicationStateService _service;

        public ApplicationStatesController(IApplicationStateService applicationState)
        {
            _service = applicationState;
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
        public async Task<IActionResult> AddAsync(CreateApplicationStateRequest request)
        {
            return HandleDataResult(await _service.AddAsync(request));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteApplicationStateRequest request)
        {
            return HandleResult(await _service.DeleteAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationStateRequest request)
        {
            return HandleDataResult(await _service.UpdateAsync(request));
        }
    }
}
