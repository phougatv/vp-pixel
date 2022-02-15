namespace VP.Pixel.Core.Persistence.Base.Concretes;

using Microsoft.EntityFrameworkCore;
using System;
using VP.Pixel.Core.Persistence.Base;
using VP.Pixel.Core.Persistence.DbContext;

internal abstract class Repository<TEntity> : IRepository<Guid, TEntity>
    where TEntity : Entity<Guid>
{
    private readonly IUnitOfWorkDbContext<PixelDbContext> _uow;
    private readonly DbSet<TEntity> _dbSet;

    protected Repository(IUnitOfWorkDbContext<PixelDbContext> uow)
    {
        if (null == uow)
            throw new ArgumentNullException(nameof(uow));
        if (null == uow.Context)
            throw new ArgumentNullException($"{nameof(uow.Context)} in {nameof(IUnitOfWorkDbContext<PixelDbContext>)} must not be null");
        _uow = uow;
        _dbSet = uow.Context.Set<TEntity>();
    }

    #region Public Methods
    public Boolean Create(TEntity entity)
    {
        try
        {
            var entityEntry = _dbSet.Add(entity);
            if (entityEntry == null)
                throw new Exception($"Failed to add the entity to DbSet<{typeof(TEntity).FullName}>");

            return EntityState.Added == entityEntry.State;
        }
        catch (Exception ex)
        {
            //Log the exception
            return false;
        }
    }
    public Boolean Delete(Guid id)
    {
        try
        {
            var entity = InternalReadById(id);
            if (entity == null)
                return false;

            var entityEntry = _dbSet.Remove(entity);
            if (entityEntry == null)
                throw new Exception($"Failed to remove the entity from DbSet<{typeof(TEntity).FullName}>");

            return EntityState.Deleted == entityEntry.State;
        }
        catch (Exception ex)
        {
            //Log the exception
            return false;
        }
    }
    public TEntity ReadById(Guid id) => InternalReadById(id);
    public Boolean Update(TEntity entity)
    {
        try
        {
            var existingEntity = InternalReadById(entity.Id);
            if (null == existingEntity)
                throw new Exception($"Entity with id: {entity.Id} not found");

            var propertiesToBeSkipped = typeof(Entity<Guid>).GetProperties().Select(p => p.Name);
            var requiredPropertiesInfo = typeof(TEntity).GetProperties().Where(p => !propertiesToBeSkipped.Contains(p.Name));

            foreach (var propertyInfo in requiredPropertiesInfo)
            {
                var value = entity.GetType().GetProperty(propertyInfo.Name).GetValue(entity, null);
                existingEntity.GetType().GetProperty(propertyInfo.Name).SetValue(existingEntity, value);
            }

            return true;
        }
        catch (Exception ex)
        {
            //Log the exception
            return false;
        }
    }
    #endregion Public Methods

    #region Private Methods
    private TEntity InternalReadById(Guid id) => _dbSet.SingleOrDefault(entity => entity.Id == id) ?? default;
    #endregion Private Methods
}
