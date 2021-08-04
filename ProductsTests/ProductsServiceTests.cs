using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using ProductAPI.Controllers;
using ProductAPI.DB;
using ProductAPI.Mappers;
using ProductAPI.Models;
using ProductAPI.Services;
using Xunit;

namespace ProductsTests
{
    public class ProductsServiceTests : ProductsServiceDbContextTests
    {
        private ProductsDbContext _dbContext;
        private IProductsService _service;
        private IMapper _mapper;

        public ProductsServiceTests() : base(
        new DbContextOptionsBuilder<ProductsDbContext>()
            .UseInMemoryDatabase("ProductsTest")
            .Options)
        {
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductDbToProductModelMapper());
                cfg.AddProfile(new ProductModelPlayerToDbProductMapper());
                cfg.AddProfile(new ProductRequestToDbProductMapper());
                cfg.AddProfile(new ProductRequestToModelProductMapper());
            });
            _mapper = mockMapper.CreateMapper();
        }
        [Fact]
        public void RetrieveProducts_WithSuccess()
        {
            //Arrage
            using(var context = new ProductsDbContext(_contextOptions))
            {
                _service = Substitute.For<ProductsService>(context, _mapper);

                //Act
                var result = _service.GetProducts().Result;

                //Assert
                result.Count.Should().Be(3);
                result[0].Name.Should().Be("Swim Goggles");
                result[1].Description.Should().Be("The car window sun shade blocks over 97% of harmful UV Rays.");
            }
            _service.GetProducts();
        }

        [Fact]
        public void AddProducts_WithSuccess()
        {
           
            using (var context = new ProductsDbContext(_contextOptions))
            {
                //Arrage
                _service = Substitute.For<ProductsService>(context, _mapper);
                var product = new AddProductRequest
                {
                    Name = "ABC",
                    Description = "New Product",
                    Price = "$10"
                };
                //Act
                var result = _service.AddProducts(product).Result;

                //Assert
                result.Should().Be(true);
            }
            _service.GetProducts();
        }
    }
}
