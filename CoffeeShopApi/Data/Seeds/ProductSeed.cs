using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeShopApi.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasData(
                new ProductEntity
                {
                    Id = 1,
                    OrderId = null,
                    ProductName = "Café Americano",
                    Description = "Café negro preparado con agua caliente.",
                    Category = Category.Bebidas,
                    Availability = 50,
                    Price = 223,
                    Picture = new byte[0], // Aquí iría la imagen en bytes
                },
            new ProductEntity
            {
                Id = 2,
                OrderId = null,
                ProductName = "Café Latte",
                Description = "Café espresso con leche vaporizada.",
                Category = Category.Bebidas,
                Availability = 30,
                Price = 343,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 3,
                OrderId = null,
                ProductName = "Capuchino",
                Description = "Café espresso con leche vaporizada y espuma de leche.",
                Category = Category.Bebidas,
                Availability = 40,
                Price = 412,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 4,
                OrderId = null,
                ProductName = "Té Verde",
                Description = "Té verde natural con un toque de miel.",
                Category = Category.Bebidas,
                Availability = 60,
                Price = 299,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 5,
                OrderId = null,
                ProductName = "Muffin de Arándanos",
                Description = "Muffin esponjoso con arándanos frescos.",
                Category = Category.Postres,
                Availability = 20,
                Price = 399,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 6,
                OrderId = null,
                ProductName = "Croissant de Mantequilla",
                Description = "Croissant crujiente hecho con mantequilla pura.",
                Category = Category.Postres,
                Availability = 25,
                Price = 299,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 7,
                OrderId = null,
                ProductName = "Sándwich de Jamón y Queso",
                Description = "Sándwich clásico con jamón, queso y vegetales frescos.",
                Category = Category.Snacks,
                Availability = 15,
                Price = 599,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 8,
                OrderId = null,
                ProductName = "Ensalada César", 
                Description = "Ensalada fresca con pollo, crutones y aderezo César.",
                Category = Category.Snacks,
                Availability = 10,
                Price = 699,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 9,
                OrderId = null,
                ProductName = "Jugo de Naranja Natural",
                Description = "Jugo recién exprimido de naranjas frescas.",
                Category = Category.Bebidas,
                Availability = 35,
                Price = 399,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 10,
                OrderId = null,
                ProductName = "Brownie de Chocolate",
                Description = "Brownie rico y esponjoso con trozos de chocolate.",
                Category = Category.Postres,
                Availability = 18,
                Price = 499,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 11,
                OrderId = null,
                ProductName = "Café Mocha",
                Description = "Café espresso con chocolate y leche vaporizada.",
                Category = Category.Bebidas,
                Availability = 40,
                Price = 499,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 12,
                OrderId = null,
                ProductName = "Té de Manzana",
                Description = "Té de manzana con un toque de canela.",
                Category = Category.Bebidas,
                Availability = 55,
                Price = 299,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 13,
                OrderId = null,
                ProductName = "Bagel con Queso Crema",
                Description = "Bagel fresco con queso crema suave.",
                Category = Category.Snacks,
                Availability = 20,
                Price = 399,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 14,
                OrderId = null,
                ProductName = "Galletas de Avena",
                Description = "Galletas caseras de avena con pasas.",
                Category = Category.Postres,
                Availability = 30,
                Price = 299,
                Picture = new byte[0],
            },
            new ProductEntity
            {
                Id = 15,
                OrderId = null,
                ProductName = "Smoothie de Frutas",
                Description = "Smoothie refrescante con mezcla de frutas tropicales.",
                Category = Category.Bebidas,
                Availability = 25,
                Price = 599,
                Picture = new byte[0]
            }
             );

        }
    }
}
