using Microsoft.EntityFrameworkCore;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;

namespace WebApi.WebApi.src.RepoImplementations
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        private readonly DbSet<Category> _category;

        public CategoryRepo(DatabaseContext dbContext)
            : base(dbContext)
        {
            _category = dbContext.Categories;
        }

        public override async Task<Category?> GetOneById(Guid id)
        {
            try
            {
                return _category.FirstOrDefault(i => i.Id == id);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
