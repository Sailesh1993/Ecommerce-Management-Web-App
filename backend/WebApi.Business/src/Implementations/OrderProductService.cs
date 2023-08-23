using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class OrderProductService : BaseService<OrderProduct, OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>, IOrderProductService
    {
        private readonly IOrderProductRepo _orderProductRepo;
        public OrderProductService(IOrderProductRepo orderProductRepo, IMapper mapper) : base(orderProductRepo, mapper)
        {
            _orderProductRepo = orderProductRepo;
        }

        public override async Task<OrderProductReadDto> CreateOne(OrderProductCreateDto createDto)
        {
            if(createDto.ProductId.Equals(Guid.Empty)) throw new Exception("OrderId and ProductId can't be empty");
            if(createDto.Quantity <= 0) throw new Exception("Quantity cannot be less than 0");
            var createdEntity = await base.CreateOne(createDto) ?? throw new Exception("Error occured while creating new orderProduct");
            return createdEntity;
        }

        public override async Task<OrderProductReadDto> UpdateOneById(Guid Id, OrderProductUpdateDto updateDto)
        {
            if(updateDto.Quantity <= 0) throw new Exception("Quantity cannot be less than or equal to 0.");
            var updatedEntity = await base.UpdateOneById(Id, updateDto) ?? throw new Exception("Error occured while updating orderProduct.");
            return updatedEntity;
        }
    }
}