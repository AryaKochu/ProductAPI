using Microsoft.EntityFrameworkCore;
using ProductAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsTests
{
    public class ProductsServiceDbContextTests
    {

        protected DbContextOptions<ProductsDbContext> _contextOptions { get; }


        protected ProductsServiceDbContextTests(DbContextOptions<ProductsDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new ProductsDbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var bob = new Product
                {
                    Id = 1,
                    Name = "Swim Goggles",
                    Description = "Flexible silicone frame and improved higher nosepiece",
                    Price = "$10.99"
                };

                var allice = new Product
                {
                    Id = 2,
                    Name = "Car Window Shade",
                    Description = "The car window sun shade blocks over 97% of harmful UV Rays.",
                    Price = "$11.87"
                };

                var ryan = new Product
                {
                    Id = 3,
                    Name = "Duvet Cover 3 Piece Set",
                    Description = "PREMIUM HIGH-QUALITY MATERIAL",
                    Price = "$21.20"
                };

                context.AddRange(bob, allice, ryan);

                context.SaveChanges();
            }
        }

    }
}
