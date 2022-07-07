using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ConsignmentApi.Models;
using ConsignmentApi.Services;

namespace ConsignmentApi.Controllers;

[Route("api/[controller]")]
[ApiController]

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

}
