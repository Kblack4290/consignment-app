using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ConsignmentApi.Models;
using ConsignmentApi.Services;
using Microsoft.AspNetCore.Cors;



namespace ConsignmentApi.Controllers;

// [Authorize]
[Route("api/[controller]")]
[ApiController]
// [EnableCors("MyCorsImplementationPolicy")]



public class UsersController : Controller
{
    private readonly UserService service;

    public UsersController(UserService _service)
    {
        service = _service;
    }

    [HttpGet]

    public ActionResult<List<User>> GetUsers()
    {
        return service.GetUsers();
    }

    [HttpGet("{id:length(24)}")]

    public ActionResult<User> GetUser(string id)
    {
        var user = service.GetUser(id);

        return Json(user);
    }

    [HttpPost]
    public ActionResult<User> Create(User user)
    {
        service.Create(user);

        return Json(user);
    }

    [Route("authenticate")]
    [HttpPost]

    public ActionResult Login([FromBody] User user)
    {

        var token = service.Authenticate(user.Email, user.Password);

        if (token == null)
            return Unauthorized();

        return Ok(new { token, user });
    }

}


