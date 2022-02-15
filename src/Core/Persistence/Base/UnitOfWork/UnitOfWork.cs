namespace VP.Pixel.Core.Persistence.Base.UnitOfWork;

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

    public Int32 Commit() => Context.SaveChanges();

    public TRepository GetRepository<TRepository>()
        => (TRepository)_serviceProvider.GetRequiredService(typeof(TRepository));
}
