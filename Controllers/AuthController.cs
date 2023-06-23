
using Microsoft.AspNetCore.Mvc;
using ConsignmentApi.Models;

namespace ConsignmentApi.Controllers;



public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] User user)
    {
        var token = _authenticationService.Authenticate(user.Email, user.Password);

        if (token == null)
            return Unauthorized();

        return Ok(new { token, user });
    }
}