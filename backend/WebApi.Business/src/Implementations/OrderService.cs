using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class OrderService
        : BaseService<Order, OrderReadDto, OrderCreateDTo, OrderUpdateDto>,
            IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly ICartRepo _cartRepo;
        private readonly IOrderProductRepo _orderProductRepo;

        public OrderService(
            IOrderRepo orderRepo,
            IMapper mapper,
            ICartRepo cartRepo,
            IOrderProductRepo orderProductRepo
        )
            : base(orderRepo, mapper)
        {
            _orderRepo = orderRepo;
            _cartRepo = cartRepo;
            _orderProductRepo = orderProductRepo;
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByUserId(Guid userId)
        {
            var orders = await _orderRepo.GetOrdersByUserId(userId);
            return _mapper.Map<IEnumerable<OrderReadDto>>(orders);
        }

        public async Task<OrderReadDto> UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            return _mapper.Map<OrderReadDto>(
                await _orderRepo.UpdateOrderStatus(orderId, orderStatus)
            );
        }

        public override async Task<OrderReadDto> CreateOne(OrderCreateDTo orderCreateDTo)
        {
            var userCart = await _cartRepo.GetUserCartDetails(orderCreateDTo.UserId);
            if (userCart != null && userCart.CartItem.Count > 0)
            {
                var orderEntity = _mapper.Map<Order>(orderCreateDTo);
                decimal TotalAmount = 0;
                foreach (var cartItem in userCart.CartItem)
                {
                    TotalAmount += cartItem.Product.Price * cartItem.Quantity;
                }
                orderEntity.TotalAmount = TotalAmount;
                var entity = await _orderRepo.CreateOne(orderEntity);

                var orderProducts = _mapper.Map<List<OrderProduct>>(userCart.CartItem);
                foreach (var item in orderProducts)
                {
                    item.OrderId = entity.Id;
                    item.ProductPrice = item.Product.Price;
                    await _orderProductRepo.CreateOne(item);
                }
                var cartEntity = await _cartRepo.GetOneById(userCart.Id);
                cartEntity.IsActive=false;
                await _cartRepo.UpdateOneById(cartEntity);
                
                return await GetUserOrderDetails(entity.Id);
            }
            else
            {
                return null;
            }
        }

        public async Task<OrderReadDto> GetUserOrderDetails(Guid OrderId)
        {
            var orderDetails = _orderRepo.GetOrderDetails(OrderId);
            decimal TotalAmount = 0;
            if (orderDetails.Result != null)
            {
                foreach (var orderItem in orderDetails.Result.OrderProducts)
                {
                    TotalAmount += orderItem.ProductPrice * orderItem.Quantity;
                }
                var orderDetail = _mapper.Map<OrderReadDto>(orderDetails.Result);
                orderDetail.TotalAmount = TotalAmount;
                return orderDetail;
            }
            else
            {
                return null;
            }
        }
    }
}
