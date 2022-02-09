namespace VP.Pixel.WebAPI.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserDbContext _dbContext;

    public UsersController(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        //if (user.Id < 1)
        //    throw new ArgumentOutOfRangeException(nameof(user.Id));
        if (String.IsNullOrEmpty(user.EmailId))
            throw new ArgumentNullException(nameof(user.EmailId));

        var entityEntry = _dbContext.Users.Add(user);
        if (entityEntry == null)
            throw new Exception($"Failed to add user");

        var isSuccessfullyAdded = EntityState.Added == entityEntry.State;

        try
        {
            _dbContext.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            //Log the exception message -> ex.Message
        }

        return StatusCode(StatusCodes.Status409Conflict, "Failed to create user");
    }

    [HttpGet("{id}")]
    public IActionResult ReadUser(Guid id)
    {
        if (Guid.Empty == id)
            return BadRequest("Invalid input");
        var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }
}
