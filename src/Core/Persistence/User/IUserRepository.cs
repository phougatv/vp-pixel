namespace VP.Pixel.Core.Persistence.User;
public interface IUserRepository
{
    Boolean Create(User user);
    User ReadById(Guid id);
}
