namespace VP.Pixel.WebAPI.Users.DataAccess.Poco;

using VP.Pixel.Shared.Persistence.Base;

public class User : Entity<Guid>
{
    public String EmailId { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }
}
