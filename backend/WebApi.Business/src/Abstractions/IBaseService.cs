using WebApi.Domain.src.Shared;

namespace WebApi.Business.src.Abstractions
{
    public interface IBaseService<T,TReadDto, TCreateDto, TUpdateDto>
    {
         Task <IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions); 
        Task <TReadDto> GetOneById(string id);
        Task <TReadDto> UpdateOneById(string id, TUpdateDto updated);
        Task <bool> DeleteOneByID(string id);
        Task<TReadDto> CreateOne(TCreateDto dto);
    }
}

