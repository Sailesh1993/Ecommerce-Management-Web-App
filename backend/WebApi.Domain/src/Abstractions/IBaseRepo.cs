using WebApi.Domain.src.Shared;

namespace WebApi.Domain.src.Abstractions
{
    public interface IBaseRepo<T> // repo should not work with Dto, but original entities
    {
        IEnumerable<T> GetAll(QueryOptions queryOptions); // should consider the sorting, searching, pagination
        T GetOneById(string id);
        T UpdateOneById(T originalEntity, T updatedEntity);
        bool DeleteOneByID(T entity);
    }
}