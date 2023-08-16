using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Abstractions
{
    public interface ICartService : IBaseService<Cart, CartReadDto, CartCreateDto,CartUpdateDto>
    {
        
    }
}