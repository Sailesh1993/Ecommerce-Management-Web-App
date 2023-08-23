using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.Domain.src.Shared;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class OrderRepo: BaseRepo<Order>, IOrderRepo
    {
        private readonly DbSet<Order> _order;
        private readonly DatabaseContext _context;


        public OrderRepo(DatabaseContext context) : base(context)
        {
            _context = context;
            _order = context.Orders;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId)
        {
            return await _context.Orders
                .Include(o => o.OrderProducts) // Include the related OrderProducts
                .Where(o => o.UserId == userId)
                .ToListAsync();

            //return await _order.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<Order> UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            var entity = await _order.FindAsync(orderId);
            if (entity == null)
            {
                throw new Exception("Order not found");
            }
            entity.OrderStatus = orderStatus;
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Order?> GetOneById(Guid id)
        {
            try
            {
                return _order.FirstOrDefault(i => i.Id == id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}