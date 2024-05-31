using Application.Features.UserImages.Commands.Create;
using Application.Features.UserImages.Commands.Delete;
using Application.Features.UserImages.Commands.Update;
using Application.Features.UserImages.Queries.GetById;
using Application.Features.UserImages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserImagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserImageCommand createUserImageCommand)
    {
        CreatedUserImageResponse response = await Mediator.Send(createUserImageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserImageCommand updateUserImageCommand)
    {
        UpdatedUserImageResponse response = await Mediator.Send(updateUserImageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedUserImageResponse response = await Mediator.Send(new DeleteUserImageCommand { Id = id });

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