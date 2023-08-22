using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class CartRepo : BaseRepo<Cart>, ICartRepo
    {
        private readonly DbSet<Cart> _cart;
        private readonly DbSet<CartItem> _cartItem;

        public CartRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _cart = dbContext.Carts;
            _cartItem = dbContext.CartItems;

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
        public async Task<Cart?> GetUserCartDetails(Guid UserId)
        {
            try
            {
                var cartInfo =  _cart.Include(t=>t.CartItem.Where(ci => ci.IsActive))
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(i => i.UserId == UserId && i.IsActive == true );
                return cartInfo;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }

    }
}