using CoffeeShopApi.Data.Entities;

namespace CoffeeShopApi.Domain.DTO
{
    public class OrderDTO
    {
        public DateTime OrderTime { get; set; }

        public virtual required string ClientFullName {get; set;}

        public State State { get; set; }

        public int TotalPay { get; set; } = 0;

        public int TotalPaid { get; set; } = 0;

        public PaymentMethod Payment { get; set; }

        public virtual IEnumerable<ProductEntity> Products { get; set; } = [];
    }
}
