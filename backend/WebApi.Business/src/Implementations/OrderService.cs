using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class OrderService : BaseService<Order, OrderReadDto, OrderCreateDTo, OrderUpdateDto>, IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo, IMapper mapper) : base(orderRepo, mapper)
        {
            _orderRepo = orderRepo;
        }

         public async Task<IEnumerable<OrderReadDto>> GetOrdersByUserId(Guid userId)
        {
            var orders = await _orderRepo.GetOrdersByUserId(userId);
            return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
        }
    
        public async Task<OrderReadDto> UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            return _mapper.Map<OrderReadDto>(await _orderRepo.UpdateOrderStatus(orderId, orderStatus));
        }

        public override async Task<OrderReadDto> CreateOne(OrderCreateDTo createDto)
        {
            if(createDto.UserId.Equals(Guid.Empty))
            {
                throw new Exception("User cannot be null");
            }
            return await base.CreateOne(createDto);
        }
    }
}