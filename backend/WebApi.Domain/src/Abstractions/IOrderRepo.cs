using WebApi.Domain.src.Entities;

namespace WebApi.Domain.src.Abstractions
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserId(Guid UserId);
        Task<Order> UpdateOrderStatus(Guid OrderId, OrderStatus orderStatus);
    }
}