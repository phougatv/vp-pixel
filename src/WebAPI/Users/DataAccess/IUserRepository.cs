namespace VP.Pixel.WebAPI.Users.DataAccess;

using VP.Pixel.Shared.Persistence.Base;
using VP.Pixel.WebAPI.Users.DataAccess.Poco;

public interface IUserRepository : IRepository<Guid, User>
{

}
