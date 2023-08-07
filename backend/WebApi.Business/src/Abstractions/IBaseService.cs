using WebApi.Domain.src.Shared;

namespace WebApi.Business.src.Abstractions
{
    public interface IBaseService<T, TDto>
    {
         IEnumerable<TDto> GetAll(QueryOptions queryOptions); 
        TDto GetOneById(string id);
        TDto UpdateOneById(string id, TDto updated);
        bool DeleteOneByID(string id);
    }
}