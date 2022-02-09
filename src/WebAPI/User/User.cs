namespace VP.Pixel.WebAPI.User;

public class User
{
    public Guid Id { get; set; }
    public String EmailId { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
