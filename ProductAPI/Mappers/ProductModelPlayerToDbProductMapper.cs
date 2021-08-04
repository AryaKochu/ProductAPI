using AutoMapper;

namespace ProductAPI.Mappers
{
    public class ProductModelPlayerToDbProductMapper : Profile
    {
        public ProductModelPlayerToDbProductMapper()
        {
            CreateMap<Models.Product, DB.Product>();
        }
    }
}
