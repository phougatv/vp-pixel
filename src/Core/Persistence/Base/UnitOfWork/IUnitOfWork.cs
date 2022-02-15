namespace VP.Pixel.Core.Persistence.Base.UnitOfWork;

public interface IUnitOfWork
{
    Int32 Commit();
    TRepository GetRepository<TRepository>();
}
