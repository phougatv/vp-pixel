﻿namespace VP.Pixel.WebAPI.Users.DataAccess;

using VP.Pixel.Shared.Persistence.Base;
using VP.Pixel.Shared.Persistence.Base.Concretes;
using VP.Pixel.WebAPI;
using VP.Pixel.WebAPI.Users.DataAccess.Poco;

internal class UserRepository : Repository<Guid, User, AppDbContext>, IUserRepository
{
    public UserRepository(IUnitOfWorkDbContext<AppDbContext> uow)
        : base(uow)
    {

    }
}
