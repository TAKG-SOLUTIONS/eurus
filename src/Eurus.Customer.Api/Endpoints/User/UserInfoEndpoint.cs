using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Eurus.Customer.Api.Endpoints.User;

public record UserResult(string Email);

public class UserInfoEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<UserResult>
{
    [HttpGet("/me")]
    public override Task<ActionResult<UserResult>> HandleAsync(CancellationToken cancellationToken = new())
    {
        var userResult = new UserResult(Email: "sumihiran.me");
        return Task.FromResult<ActionResult<UserResult>>(Ok(userResult));
    }
}