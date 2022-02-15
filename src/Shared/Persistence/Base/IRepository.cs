namespace VP.Pixel.Shared.Persistence.Base;

public interface IRepository<TId, TEntity>
    where TId : struct, IEquatable<TId>
    where TEntity : class
{
    Boolean Create(TEntity entity);
    Boolean Delete(TId id);
    TEntity ReadById(TId id);
    Boolean Update(TEntity entity);
}
