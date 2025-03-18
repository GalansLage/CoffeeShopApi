using CoffeeShopApi.Data.Entities;

namespace CoffeeShopApi.Application.InsertDTO
{
    public class OrderInsertDTO
    {
        public  int ClientId { get; set; }

        public PaymentMethod Payment { get; set; }
    }
}
