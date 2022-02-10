namespace VP.Pixel.Core.Persistence.DbContext;

using Microsoft.EntityFrameworkCore;
using VP.Pixel.Core.Persistence.User;

internal class PixelDbContext : DbContext
{
    public PixelDbContext(DbContextOptions<PixelDbContext> options)
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
