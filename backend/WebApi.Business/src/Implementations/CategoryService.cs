using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class CategoryService : BaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>, ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper) : base(categoryRepo, mapper)
        {
            _categoryRepo = categoryRepo;
        }
        public override async Task<CategoryReadDto> UpdateOneById(Guid id, CategoryUpdateDto updateDto)
        {
            var foundCategory = await _categoryRepo.GetOneById(id);
            if(foundCategory == null)
            {
                throw new Exception("Category not found");
            }
            foundCategory.Name = updateDto.Name;
            var updated = await _categoryRepo.UpdateOneById(foundCategory);
            return _mapper.Map<CategoryReadDto>(updated); 
        }
    }
}