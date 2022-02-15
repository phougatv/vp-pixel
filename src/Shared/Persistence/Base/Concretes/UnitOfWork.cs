namespace VP.Pixel.Shared.Persistence.Base.Concretes;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VP.Pixel.Shared.Persistence.Base;

public class UnitOfWork<TContext> : IUnitOfWork, IUnitOfWorkDbContext<TContext>
    where TContext : DbContext
{
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWork(TContext _dbContext, IServiceProvider serviceProvider)
    {
        Context = _dbContext;
        _serviceProvider = serviceProvider;
    }

    public TContext Context { get; }

    public Int32 Commit()
    {
        var utcNow = DateTime.UtcNow;
        foreach (var changedEntity in Context.ChangeTracker.Entries())
        {
            if (changedEntity.Entity is not Entity<Guid> entity)
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
