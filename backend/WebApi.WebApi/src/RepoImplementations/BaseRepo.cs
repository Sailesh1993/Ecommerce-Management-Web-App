using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Shared;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly DbSet<T> _dbset;
        private readonly DatabaseContext _context;
        public BaseRepo(DatabaseContext dbContext)
        {
            _dbset = dbContext.Set<T>();
            _context = dbContext;
        }
        public Task<T> CreateOne(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneByID(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(QueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetOneById(string id)
        {
            return await _dbset.FindAsync(id);
        }

        public Task<T> UpdateOneById(T originalEntity, T updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}