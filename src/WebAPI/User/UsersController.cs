namespace VP.Pixel.WebAPI.User;

using Microsoft.AspNetCore.Mvc;
using VP.Pixel.Core.Persistence.User;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        if (String.IsNullOrEmpty(user.EmailId))
            throw new ArgumentNullException(nameof(user.EmailId));

        var isCreated = _userRepository.Create(user);
        if (isCreated)
            return Ok();
        return StatusCode(StatusCodes.Status409Conflict, "Failed to create user");
    }

    [HttpGet("{id}")]
    public IActionResult ReadUser(Guid id)
    {
        if (Guid.Empty == id)
            return BadRequest("Invalid input");

        var user = _userRepository.ReadById(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }
}
