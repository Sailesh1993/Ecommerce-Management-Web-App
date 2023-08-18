using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class OrderRepo: BaseRepo<Order>, IOrderRepo
    {
        private readonly DbSet<Order> _order;

        public OrderRepo(DatabaseContext dbContext) : base(dbContext)
        {
            _order = dbContext.Orders;
        }

        public override async Task<Order?> GetOneById(Guid id)
        {
            try
            {
                return _order.FirstOrDefault(i => i.Id == id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}