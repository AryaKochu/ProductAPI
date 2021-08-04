using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DB;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    public class ProductsService : IProductsService
    {
        private ProductsDbContext _dbContext;
        private IMapper _mapper;

        public ProductsService(ProductsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> AddProducts(AddProductRequest playerDetails)
        {
            var totalRecordsSavedToDb = 0;
            var savedProducts = await GetDataFromDb();
            var newProduct = _mapper.Map<AddProductRequest, Models.Product>(playerDetails);

            if(savedProducts == null)
            {
                totalRecordsSavedToDb++;
                savedProducts = new List<Models.Product> { newProduct };

                _dbContext.AddRange(_mapper.Map<IEnumerable<Models.Product>, IEnumerable<DB.Product>>(savedProducts));
                
            }
            else
            {
                savedProducts.Add(newProduct);
                var productToDbEntity =
                       _mapper.Map<IEnumerable<Models.Product>, IEnumerable<DB.Product>>(savedProducts);

                foreach (var product in productToDbEntity)
                {
                    totalRecordsSavedToDb++;
                    var local = _dbContext.Set<DB.Product>()
                        .Local
                        .FirstOrDefault(entry => entry.Id.Equals(product.Id));

                    // check if local is not null 
                    if (local != null)
                    {
                        // detach
                        _dbContext.Remove(local);
                    }

                    _dbContext.Products.Add(product);
                }
            }

            var result = _dbContext.SaveChanges();

            return result == totalRecordsSavedToDb;
        }

        public async Task<IList<Models.Product>> GetProducts()
        {
            return await GetDataFromDb();
        }

        private async Task<IList<Models.Product>> GetDataFromDb()
        {
            var products = await _dbContext.Products.ToListAsync();
            if (products != null && products.Any())
            {
                var result = _mapper.Map<IEnumerable<DB.Product>, IEnumerable<Models.Product>>(products).ToList();
                return result;
            }

            return null;
        }
    }
}
