using System.Reflection.Metadata.Ecma335;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.ToList();
        return users;
    }

    [HttpGet("{id}")] //api/user/2
    public ActionResult<AppUser> GetUsers(int id)
    {
        return _context.Users.Find(id);
         
    }
}
