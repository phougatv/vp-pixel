namespace VP.Pixel.WebAPI.Test;

using Microsoft.AspNetCore.Mvc;
using VP.Pixel.Shared.Persistence.Base;
using VP.Pixel.WebAPI;

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    private readonly IUnitOfWorkDbContext<AppDbContext> _uowContext;
    public TestController(IUnitOfWork uow, IUnitOfWorkDbContext<AppDbContext> uowContext)
    {
        if (null == uow)
            throw new ArgumentNullException(nameof(uow));
        if (null == uowContext)
            throw new ArgumentNullException(nameof(uowContext));

        _uow = uow;
        _uowContext = uowContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}
