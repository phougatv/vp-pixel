namespace VP.Pixel.Shared.Persistence.Base;

public interface IUnitOfWorkDbContext<TContext>
{
    TContext Context { get; }
}
