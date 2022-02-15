namespace VP.Pixel.Core.Persistence.Base.UnitOfWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VP.Pixel.Core.Persistence.DbContext;

public class UnitOfWork : IUnitOfWork, IUnitOfWorkDbContext<PixelDbContext>
{
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWork(PixelDbContext pixelDbContext, IServiceProvider serviceProvider)
    {
        Context = pixelDbContext;
        _serviceProvider = serviceProvider;
    }

    public PixelDbContext Context { get; }

    public Int32 Commit()
    {
        var utcNow = DateTime.UtcNow;
        foreach (var changedEntity in Context.ChangeTracker.Entries())
        {
            if (changedEntity.Entity is not BaseEntity entity)
                continue;
            if (changedEntity.State == EntityState.Modified)
            {
                Context.Entry(entity).Property(p => p.CreatedOn).IsModified = false;
                entity.UpdatedOn = utcNow;
                continue;
            }
            if (changedEntity.State == EntityState.Added)
            {
                entity.CreatedOn = utcNow;
                entity.UpdatedOn = null;
            }
        }

        return Context.SaveChanges();
    }

    public TRepository GetRepository<TRepository>()
        => (TRepository)_serviceProvider.GetRequiredService(typeof(TRepository));
}
