using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.Controller.src.Controllers
{
    public class ProductController : BaseController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        public ProductController(IProductService baseService) : base(baseService)
        {
            
        }   
    }
}