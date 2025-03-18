using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;
namespace CoffeeShopApi.Utils.Mappers
{
   
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this ProductEntity entity)
        {
            var money = new MoneyEntity(entity.Price);
            return new ProductDTO
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                Availability = entity.Availability,
                Category = entity.Category,
                Description = entity.Description,
                Picture = entity.Picture,
                Price = money.Cash
            };
        }
            
      
    }
}
