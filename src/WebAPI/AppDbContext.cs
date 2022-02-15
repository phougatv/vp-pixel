namespace VP.Pixel.WebAPI;

using Microsoft.EntityFrameworkCore;
using VP.Pixel.WebAPI.Users.DataAccess.Poco;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            //Remove pluralizing table name convention (Install package - Microsoft.EntityFrameworkCore.Relational)
            entity.SetTableName(entity.DisplayName());
        }

        base.OnModelCreating(builder);
    }

    internal DbSet<User> Users { get; set; }
}
