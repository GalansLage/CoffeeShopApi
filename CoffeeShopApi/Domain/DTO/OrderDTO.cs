using CoffeeShopApi.Data.Entities;

namespace CoffeeShopApi.Domain.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }

        public string ClientFullName { get; set; } = "";

        public State State { get; set; }

        public decimal TotalPay { get; set; } = 0;

        public decimal TotalPaid { get; set; } = 0;

        public PaymentMethod Payment { get; set; }

        public  IEnumerable<ProductDTO> Products { get; set; } = [];
    }
}
