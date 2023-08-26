using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.Domain.src.Shared;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly DbSet<Product> _products;
        private readonly DatabaseContext _context;

        public ProductRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _products = dbContext.Products;
            _context = dbContext;
            
        }

        public override async Task<Product?> GetOneById(Guid id)
        {
            return await _products
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public override async Task<IEnumerable<Product?>> GetAll(QueryOptions queryOptions)
        {
            return await _products.Include(p => p.Category).ToArrayAsync();
        } 

        public override async Task<Product> CreateOne(Product entity)
        {
            await _products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
    }
}