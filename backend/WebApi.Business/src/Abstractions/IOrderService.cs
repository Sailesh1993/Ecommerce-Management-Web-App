using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Abstractions
{
    public interface IOrderService: IBaseService<Order, OrderReadDto, OrderCreateDTo,OrderUpdateDto>
    {
        Task<IEnumerable<OrderReadDto>> GetOrdersByUserId(Guid UserId);
        Task<OrderReadDto> UpdateOrderStatus(Guid orderId, OrderStatus orderStatus);
    }
}