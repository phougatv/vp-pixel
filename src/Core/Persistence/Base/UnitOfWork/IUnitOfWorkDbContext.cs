namespace VP.Pixel.Core.Persistence.Base.UnitOfWork;

public interface IUnitOfWorkDbContext<TContext>
{
    TContext Context { get; }
}
