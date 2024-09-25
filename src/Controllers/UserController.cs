using App.Data.Payloads;
using App.Data.Responses;
using App.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("user")]
public class UserController(UserService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserPayload payload)
    {
        var response = await service.CreateUser(payload);
        return Created("/user", new DefaultResponse<UserDTO>("User created successfully!", response));
    }

    [HttpPost("update")]
    public async Task<ActionResult> UpdateUser(UpdateUserPayload payload)
    {
        var response = await service.UpdateUser(payload);
        return Ok(new DefaultResponse<UserDTO>("User updated successfully!", response));
    }

    [HttpGet]
    public async Task<ActionResult> GetUser(Guid id)
    {
        var response = await service.GetUserById(id);
        return Ok(new DefaultResponse<UserDTO>("User found!", response));
    }
}