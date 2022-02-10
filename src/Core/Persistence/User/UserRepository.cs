namespace VP.Pixel.Core.Persistence.User;
using VP.Pixel.Core.Persistence.Base.Implementations;
using VP.Pixel.Core.Persistence.DbContext;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly PixelDbContext _pixelDbContext;
    public UserRepository(PixelDbContext pixelDbContext)
        : base(pixelDbContext)
    {
        _pixelDbContext = pixelDbContext;
    }
}
