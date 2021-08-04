using ProductAPI.Models;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public class ProductsResponse
    {
        public IList<Product> Products { get; set; }
    }
}