using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;
using WebApi.Domain.src.Shared;

namespace WebApi.Controller.src.Controllers
{
    public class ProductController : BaseController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService baseService, IMapper mapper) : base(baseService)
        {
            _productService = baseService;
            _mapper = mapper;
        }  

        [AllowAnonymous]
        public override async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll([FromQuery] QueryOptions queryOptions) 
        {
            try
            {
                var productList = await base.GetAll(queryOptions);
                if (productList == null)
                {
                    return NotFound();
                }
                return Ok(productList);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Error while processing request");
            }
        }

        [AllowAnonymous]
        public override async Task<ActionResult<ProductReadDto>> GetOneById([FromRoute] Guid id)
        {
            var foundProduct = await base.GetOneById(id);
            if(foundProduct == null)
            {
                return NotFound();
            }
            return Ok(foundProduct);
        }

        public override async Task<ActionResult<ProductReadDto>> CreateOne([FromBody] ProductCreateDto createDto)
        {
            var createdProduct = await _productService.CreateOne(createDto);
            return CreatedAtAction(nameof(CreateOne), createdProduct);
        } 

        [AllowAnonymous]
        public override async Task<ActionResult<ProductReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] ProductUpdateDto updateDto)
        {
            return await _productService.UpdateOneById(id, updateDto);
        }

        [AllowAnonymous]
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id)
        {
            return StatusCode(204, await _productService.DeleteOneByID(id));
        }
 
    }
}