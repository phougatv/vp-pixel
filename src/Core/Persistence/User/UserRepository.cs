namespace VP.Pixel.Core.Persistence.User;

using VP.Pixel.Core.Persistence.Base.Repository;
using VP.Pixel.Core.Persistence.Base.UnitOfWork;
using VP.Pixel.Core.Persistence.DbContext;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IUnitOfWorkDbContext<PixelDbContext> uow)
        : base(uow)
    {

    }
}
