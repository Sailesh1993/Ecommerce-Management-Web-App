using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Entities;

namespace WebApi.Controller.src.Controllers
{
    public class CategoryController : BaseController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) : base(categoryService)
        {
            _categoryService = categoryService;
        }

        /* [Authorize(Roles = "Admin")] */
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id)
        {
            return await base.DeleteOneById(id);
        }

        /* /* [Authorize(Roles = "Admin")] */
        public override async Task<ActionResult<CategoryReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] CategoryUpdateDto updateDto)
        {
            return await base.UpdateOneById(id, updateDto);
        }

        /* [Authorize(Roles = "Admin")] */
        public override async Task<ActionResult<CategoryReadDto>> CreateOne([FromBody] CategoryCreateDto createDto)
        {
            return await base.CreateOne(createDto);
        }

        
     }
}