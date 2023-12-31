using WebApi.Domain.src.Entities;

namespace WebApi.Domain.src.Abstractions
{
    public interface ICartRepo: IBaseRepo<Cart>
    {
        Task<Cart> GetUserCartDetails(Guid UserId);
    }
}