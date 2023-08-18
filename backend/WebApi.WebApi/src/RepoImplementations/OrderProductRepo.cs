using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class OrderProductRepo : BaseRepo<OrderProduct>, IOrderProductRepo
    {
        private readonly DbSet<OrderProduct> _orderProduct;

        public OrderProductRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _orderProduct = dbContext.OrderProducts;
        }

        public override async Task<OrderProduct?> GetOneById(Guid id)
        {
            try
            {
                return _orderProduct.FirstOrDefault(i => i.Id == id);
            }
            catch (System.Exception ex)
            {
                
                throw  ex;
            }
        }
    }
}