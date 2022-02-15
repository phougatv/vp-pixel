namespace VP.Pixel.Shared.Persistence.Base;

public interface IUnitOfWork
{
    Int32 Commit();
    TRepository GetRepository<TRepository>();
}
