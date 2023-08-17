using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class CartService : BaseService<Cart, CartReadDto, CartCreateDto, CartUpdateDto>, ICartService
    {
        public CartService(ICartRepo cartRepo, IMapper mapper) : base(cartRepo, mapper)
        {
        }
    }
}