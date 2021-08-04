using AutoMapper;

namespace ProductAPI.Mappers
{
    public class ProductDbToProductModelMapper : Profile
    {
        public ProductDbToProductModelMapper()
        {
            CreateMap<DB.Product, Models.Product>();
        }
    }
}
