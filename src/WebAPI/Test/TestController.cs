namespace VP.Pixel.WebAPI.Test;

using Microsoft.AspNetCore.Mvc;
using VP.Pixel.Core.Persistence.Base;
using VP.Pixel.Core.Persistence.DbContext;

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IUnitOfWork _uow;
    private readonly IUnitOfWorkDbContext<PixelDbContext> _uowContext;
    public TestController(IUnitOfWork uow, IUnitOfWorkDbContext<PixelDbContext> uowContext)
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
