using Microsoft.EntityFrameworkCore;
using WebApi.Controller.src.Controllers;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class CartItemRepo : BaseRepo<CartItem>, ICartItemRepo
    {
        private readonly DbSet<CartItem> _cartItem;

        public CartItemRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _cartItem = dbContext.CartItems;
        }

        public async Task<CartItem?> GetOneById(Guid id)
        {
            try
            {
                return _cartItem.FirstOrDefault(i => i.Id == id);

            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
    }
}