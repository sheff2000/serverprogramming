using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserDbContext _context;

    public UsersController(UserDbContext context)
    {
        _context = context;
    }

    // GET: Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsersTable>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
}
