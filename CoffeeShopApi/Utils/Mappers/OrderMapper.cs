using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;

namespace CoffeeShopApi.Utils.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO ToDTO(OrderEntity entity)
            => new OrderDTO
            {
                OrderTime = entity.OrderTime,
                Payment = entity.Payment,
                Products = entity.Products,
                State = entity.State,
                TotalPaid = entity.TotalPaid,
                TotalPay = entity.TotalPay,
                ClientFullName = entity.Client!.ClientName + " " + entity.Client.ClientLastName
            };
    }
}
