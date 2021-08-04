using AutoMapper;
using ProductAPI.Controllers;

namespace ProductAPI.Mappers
{
    public class ProductRequestToModelProductMapper : Profile
    {
        public ProductRequestToModelProductMapper()
        {
            CreateMap<Models.AddProductRequest, Models.Product>();
        }
    }
}
