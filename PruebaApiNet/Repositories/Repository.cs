
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PruebaApiNet.SakilaDatabase;

namespace PruebaApiNet.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {   
        protected SakilaMasterContext Context { get; init; }
        public Repository(SakilaMasterContext context) {
            Context = context;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToArrayAsync();
        }

        public IQueryable<TEntity> GetQueryable(bool asNoTraking = true)
        {
            DbSet<TEntity> entities = Context.Set<TEntity>();

            return asNoTraking ? entities.AsNoTracking() : entities;
        }


        //REPASAR A PARTIR DE AQUI
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            EntityEntry<TEntity> entry = await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return entry.Entity;
        }

        //public async Task<bool> SaveAsync()
        //{
        //    return await Context.SaveChangesAsync() > 0;
        //}
    }
}

