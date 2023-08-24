using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;
using WebApi.Domain.src.Shared;

namespace WebApi.Controller.src.Controllers
{
    public class OrderController : BaseController<Order, OrderReadDto, OrderCreateDTo, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }
        
        
        [Authorize(Roles = "Admin")]
        [HttpGet("{id:Guid}/{userId:Guid}")]
         public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrdersByUserId([FromQuery] Guid userId)
        {
            return Ok(await _orderService.GetOrdersByUserId(userId));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:Guid}/{orderId:Guid}")]
        public async Task<ActionResult<OrderReadDto>> UpdateOrderStatus([FromQuery] Guid orderID, [FromBody] OrderStatus orderStatus)
        {
            return Ok(await _orderService.UpdateOrderStatus(orderID, orderStatus));
        }
        
        [Authorize]
        public override async Task<ActionResult<OrderReadDto>> CreateOne([FromBody] OrderCreateDTo createDto)
        {
            return await base.CreateOne(createDto);
        }

        [Authorize]
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid Id)
        {
            return await base.DeleteOneById(Id);
        }

        [Authorize (Roles ="Admin")]
        public override async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            return await base.GetAll(queryOptions);
        }

        [Authorize (Roles ="Admin")]
        public override async Task<ActionResult<OrderReadDto>> GetOneById([FromRoute] Guid Id)
        {
            return await base.GetOneById(Id);
        }

        [Authorize]
        public override async Task<ActionResult<OrderReadDto>> UpdateOneById([FromRoute] Guid Id, [FromBody] OrderUpdateDto updateDto)
        {
            return await base.UpdateOneById(Id, updateDto);
        }
    }
}