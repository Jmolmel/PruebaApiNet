namespace PruebaApiNet.Repositories;

public interface IRepository<TEntity, TId> where TEntity : class
{
    Task<ICollection<TEntity>> GetAllAsync();
    IQueryable<TEntity> GetQueryable(bool asNoTraking = true);
    Task<TEntity> InsertAsync(TEntity entity);
    //Task<bool> SaveAsync();
}
