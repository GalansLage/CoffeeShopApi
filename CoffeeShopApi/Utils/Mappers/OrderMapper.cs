using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;

namespace CoffeeShopApi.Utils.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO ToDTO(OrderEntity entity)
        {
            var moneyPay = new MoneyEntity(entity.TotalPay);
            var moneyPaid = new MoneyEntity(entity.TotalPaid);
            var productsDTO = new List<ProductDTO>(); 

            foreach(var product in entity.Products)
            {
                productsDTO.Add(ProductMapper.ToDTO(product));
            }
            Console.WriteLine(productsDTO.Count);
            Console.WriteLine(entity.Products.Count);
            return new OrderDTO
            {
                Id = entity.Id,
                OrderTime = entity.OrderTime,
                Payment = entity.Payment,
                Products = productsDTO,
                State = entity.State,
                TotalPaid = moneyPaid.Cash,
                TotalPay = moneyPay.Cash,
                ClientFullName = entity.Client?.ClientName + " " + entity.Client?.ClientLastName
            };

        }
            
    }
}
