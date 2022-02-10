namespace VP.Pixel.Core.Persistence.User;

using VP.Pixel.Core.Persistence.Base;

public class User : BaseEntity
{
    public String EmailId { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }
}
