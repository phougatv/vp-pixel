namespace VP.Pixel.Core.Persistence.Base;

public interface IUnitOfWorkDbContext<TContext>
{
    TContext Context { get; }
}
