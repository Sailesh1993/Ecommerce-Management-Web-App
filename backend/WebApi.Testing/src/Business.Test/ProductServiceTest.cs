using AutoMapper;
using Moq;
using WebApi.Business.src.Dtos;
using WebApi.Business.src.Implementations;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;

namespace WebApi.Testing.src.Business.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public async Task CreateOne_ShouldCreateProductAndReturnMappedDto()
        {
            // Arrange 
            var productCreateDto = new ProductCreateDto
            {
                
                Title = "Test_Product",
                Description = "Test_Description",
                Price = 111,
                Images = new List<string>()
            };

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = "Test_Product",
                Description = "Test_Description",
                Price = 111,
                Images = new List<string>()
            };

            var createdProductReadDto = new ProductReadDto
            {
                
                Id = product.Id,
                Title = "Test_Product",
                Description = "Test_Description",
                Price = 111,
                Images = new List<string>()
            };
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Product>(It.IsAny<ProductCreateDto>()))
                .Returns(product);
            mapperMock.Setup(m => m.Map<ProductReadDto>(It.IsAny<Product>()))
                .Returns(createdProductReadDto);
            
            var productRepoMock = new Mock<IProductRepo>();
            productRepoMock.Setup(repo => repo.CreateOne(It.IsAny<Product>()))
                .ReturnsAsync(product);

            var productService = new ProductService(
                productRepoMock.Object,
                mapperMock.Object
            );

            //Act
            var result = await productService.CreateOne(productCreateDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(createdProductReadDto.Id, result.Id);
            Assert.Equal(createdProductReadDto.Title, result.Title);
            Assert.Equal(createdProductReadDto.Description, result.Description);
            Assert.Equal(createdProductReadDto.Price, result.Price);
            Assert.Equal(createdProductReadDto.Images, result.Images);
            
            mapperMock.Verify(m => m.Map<Product>(productCreateDto), Times.Once);
            productRepoMock.Verify(repo => repo.CreateOne(product), Times.Once);
            mapperMock.Verify(m => m.Map<ProductReadDto>(product), Times.Once);
        }
    }
}