using AutoMapper;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Dtos;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Business.src.Implementations
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo, IMapper mapper) : base(productRepo, mapper)
        {
            _productRepo = productRepo;
        }
        public override async Task<ProductReadDto> CreateOne(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var createdProduct = await _productRepo.CreateOne(product);
            return _mapper.Map<ProductReadDto>(createdProduct);
        }
        public virtual async Task<ProductReadDto> UpdateOneById(Guid id, ProductUpdateDto updated)
        {
            var foundItem = await _productRepo.GetOneById(id);
            if (foundItem == null)
            {
                throw new Exception("Product not found");
            }
            foundItem.Title = updated.Title;
            foundItem.Description = updated.Description;
            foundItem.Price = updated.Price;
            foundItem.CategoryId = updated.CategoryId;

            var updatedProduct = await _productRepo.UpdateOneById(foundItem);
            return _mapper.Map<ProductReadDto> (updatedProduct);
        }    
    }
}