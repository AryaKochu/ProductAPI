using AutoMapper;
using ProductAPI.Controllers;

namespace ProductAPI.Mappers
{
    public class ProductRequestToDbProductMapper : Profile
    {
        public ProductRequestToDbProductMapper()
        {
            CreateMap<Models.AddProductRequest, Models.Product>();
        }
    }
}
