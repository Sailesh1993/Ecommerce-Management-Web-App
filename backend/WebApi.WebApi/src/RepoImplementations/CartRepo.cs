using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class CartRepo : BaseRepo<Cart>, ICartRepo
    {
        private readonly DbSet<Cart> _cart;

        public CartRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _cart = dbContext.Carts;
        }

        public override async Task<Cart?> GetOneById(Guid id)
        {
            try
            {
                return _cart.FirstOrDefault(i => i.Id == id);
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
    }
}