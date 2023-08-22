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

        public ProductRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _products = dbContext.Products;
            
        }

        public override async Task<Product?> GetOneById(Guid id)
        {
            return await _products
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public override async Task<IEnumerable<Product?>> GetAll(QueryOptions queryOptions)
        {
            return await _products.Include(p => p.Category).ToArrayAsync();
            // var items = _products
            //     .Include(p => p.Category)
            //     .Include(p => p.Title)
            //     .Include(p => p.Description)
            //     .Include(p => p.Images)
            //     .Include(p => p.Price)
            //     .AsEnumerable();

            // if(!string.IsNullOrWhiteSpace(queryOptions.Search))
            // {
            //     items = items.Where(x => x.Title.ToLower().Contains(queryOptions.Search.ToLower()));
            // }
            // items = items
            //         .Skip((queryOptions.PageNumber -1) * queryOptions.PerPage)
            //         .Take(queryOptions.PerPage);

            //         return items.ToList();
        } 
        
    }
}