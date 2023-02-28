using Data.Data;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Realizations
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class , IEntity
    {
        private readonly LibraryDbContext _dbContext;
        public BaseRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return;
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(TEntity entity)
        {
             _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
