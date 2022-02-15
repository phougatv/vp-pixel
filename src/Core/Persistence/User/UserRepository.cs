namespace VP.Pixel.Core.Persistence.User;

using VP.Pixel.Core.Persistence.Base;
using VP.Pixel.Core.Persistence.Base.Concretes;
using VP.Pixel.Core.Persistence.DbContext;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IUnitOfWorkDbContext<PixelDbContext> uow)
        : base(uow)
    {

    }
}
