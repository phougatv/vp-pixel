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
            return StatusCode(StatusCodes.Status201Created);
        return StatusCode(StatusCodes.Status409Conflict, "Failed to create user");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var isDeleted = _userRepository.Delete(id);
        if (isDeleted)
            return NoContent();
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{id}")]
    public IActionResult Read(Guid id)
    {
        if (Guid.Empty == id)
            return BadRequest("Invalid input");

        var user = _userRepository.ReadById(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPut]
    public IActionResult Update(User user)
    {
        var isUpdated = _userRepository.Update(user);
        if (isUpdated)
            return NoContent();
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
