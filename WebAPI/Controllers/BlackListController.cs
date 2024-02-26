using Business.Abstracts;
using Business.Requests.BlackList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlacklistsController : BaseController
{
    private readonly IBlackListService _blacklistService;

    public BlacklistsController(IBlackListService blacklistService)
    {
        _blacklistService = blacklistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return HandleDataResult(await _blacklistService.GetAllAsync());

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return HandleDataResult(await _blacklistService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateBlackListRequest request)
    {
        return HandleDataResult(await _blacklistService.AddAsync(request));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(DeleteBlackListRequest request)
    {
        return HandleResult(await _blacklistService.DeleteAsync(request));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateBlackListRequest request)
    {
        return HandleDataResult(await _blacklistService.UpdateAsync(request));
    }
}
