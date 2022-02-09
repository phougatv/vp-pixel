namespace VP.Pixel.Core.Persistence.User;

using Microsoft.EntityFrameworkCore;

internal class UserRepository : IUserRepository
{
    private readonly UserDbContext _userDbContext;

    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public Boolean Create(User user)
    {
        var entityEntry = _userDbContext.Users.Add(user);
        if (entityEntry == null)
            throw new Exception($"Failed to add user");

        var isSuccessfullyAdded = EntityState.Added == entityEntry.State;
        if (!isSuccessfullyAdded)
            return false;

        try
        {
            _userDbContext.SaveChanges();
            return isSuccessfullyAdded;
        }
        catch (Exception ex)
        {
            //Log the exception message -> ex.Message
            return false;
        }
    }

    public User ReadById(Guid id) => _userDbContext.Set<User>().SingleOrDefault(x => x.Id == id);
}
