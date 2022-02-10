﻿namespace VP.Pixel.Core.Persistence.Base.Contracts;

public interface IRepository<TEntity>
    where TEntity : class
{
    Boolean Create(TEntity entity);
    Boolean Delete(Guid id);
    TEntity ReadById(Guid id);
    Boolean Update(TEntity entity);
}