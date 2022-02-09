namespace VP.Pixel.Core.Persistence.User;

using Microsoft.EntityFrameworkCore;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
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
