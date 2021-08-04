using ProductAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    public interface IProductsService
    {
        Task<IList<Product>> GetProducts();
        Task<bool> AddProducts(AddProductRequest playerDetails);
    }
}