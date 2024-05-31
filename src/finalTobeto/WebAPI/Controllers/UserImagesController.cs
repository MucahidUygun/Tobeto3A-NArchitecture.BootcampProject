using Application.Features.UserImages.Queries.GetById;
using Application.Features.UserImages.Queries.GetList;
using Application.Services.UserImages;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserImagesController : BaseController


{

    private readonly IUserImageService _userImageService;

    public UserImagesController(IUserImageService userImageService)
    {
        _userImageService = userImageService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(IFormFile file, [FromForm] UserImageRequest request)
    {
        var result = await _userImageService.AddAsync(file, request);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(IFormFile file, [FromForm] UserImageUpdateRequest updateRequest)
    {
        var result = await _userImageService.UpdateAsync(file, updateRequest);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _userImageService.DeleteAsync(id);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdUserImageResponse response = await Mediator.Send(new GetByIdUserImageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserImageQuery getListUserImageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserImageListItemDto> response = await Mediator.Send(getListUserImageQuery);
        return Ok(response);
    }
}
