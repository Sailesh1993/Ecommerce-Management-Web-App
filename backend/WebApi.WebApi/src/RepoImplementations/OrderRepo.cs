using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        private readonly DbSet<Order> _order;
        private readonly DatabaseContext _context;

        public OrderRepo(DatabaseContext context)
            : base(context)
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

        public async Task<Order> GetOrderDetails(Guid OrderId)
        {
            try
            {
                var orderDetails = _order
                    .Include(t => t.OrderProducts.Where(op => op.OrderId == OrderId))
                    .ThenInclude(op => op.Product)
                    .FirstOrDefault(i => i.Id == OrderId);
                return orderDetails;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
