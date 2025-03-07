using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;
namespace CoffeeShopApi.Utils.Mappers
{
   
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this ProductEntity entity)
            => new ProductDTO
            {
                ProductName = entity.ProductName,
                Availability = entity.Availability,
                Category = entity.Category,
                Description = entity.Description,
                Picture = entity.Picture,
                Price = entity.Price
            };
      
    }
}
