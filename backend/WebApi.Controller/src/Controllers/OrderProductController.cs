using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;
using WebApi.Domain.src.Shared;

namespace WebApi.Controller.src.Controllers
{
    [Authorize]
    public class OrderProductController : BaseController<OrderProduct, OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>
    {
        private readonly IOrderProductService _orderProductService;

        public OrderProductController(IOrderProductService orderProductService) : base(orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [Authorize(Roles ="Admin")]
        public override async Task<ActionResult<OrderProductReadDto>> GetOneById(Guid Id)
        {
            return await base.GetOneById(Id);
        }

        [Authorize(Roles ="Admin")]
        public override async Task<ActionResult<IEnumerable<OrderProductReadDto>>> GetAll([FromQuery] QueryOptions queryOptions)
        {
            return await base.GetAll(queryOptions);
        }
    }
}