using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly DbSet<Product> _products;

        public ProductRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _products = dbContext.Products;
            
        }

        public override async Task<Product?> GetOneById(Guid id)
        {
            return await _products
                .FirstOrDefaultAsync(i => i.Id == id);
        }
        
    }
}