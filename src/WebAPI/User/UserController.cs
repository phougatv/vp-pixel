namespace VP.Pixel.WebAPI.User;

using Microsoft.AspNetCore.Mvc;
using VP.Pixel.Core.Persistence.Base;
using VP.Pixel.Core.Persistence.User;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    private readonly IUserRepository _userRepository;

    public UserController(IUnitOfWork uow)
    {
        if (null == uow)
            throw new ArgumentNullException(nameof(uow));

        _uow = uow;
        _userRepository = uow.GetRepository<IUserRepository>();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        if (String.IsNullOrEmpty(user.EmailId))
            throw new ArgumentNullException(nameof(user.EmailId));

        var isCreated = _userRepository.Create(user);
        var recordsCreated = _uow.Commit();
        if (!isCreated)
            return StatusCode(StatusCodes.Status500InternalServerError);
        if (recordsCreated == 1)
            return StatusCode(StatusCodes.Status201Created);
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var isDeleted = _userRepository.Delete(id);
        var recordsDeleted = _uow.Commit();
        if (!isDeleted)
            return StatusCode(StatusCodes.Status500InternalServerError);
        if (recordsDeleted == 1)
            return StatusCode(StatusCodes.Status202Accepted);
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{id}")]
    public IActionResult Read(Guid id)
    {
        if (Guid.Empty == id)
            return BadRequest();

        var user = _userRepository.ReadById(id);
        if (null == user)
            return NotFound();
        return Ok(user);
    }

    [HttpPut]
    public IActionResult Update(User user)
    {
        var isUpdated = _userRepository.Update(user);
        var recordsUpdated = _uow.Commit();
        if (!isUpdated)
            return StatusCode(StatusCodes.Status500InternalServerError);
        if (recordsUpdated == 1)
            return Ok();
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
