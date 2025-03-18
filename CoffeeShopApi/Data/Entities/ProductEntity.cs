using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Data.Entities
{
    public class ProductEntity:BaseEntity<int>
    {
        public virtual int? OrderId { get; set; }

        [MaxLength(25)]
        public string ProductName { get; set; } = null!;

        [MaxLength(125)]
        public string Description { get; set; } = null!;

        public Category Category { get; set; }

        public int Availability { get; set; } = 0;

        public int Price { get; set; } = 0;

        public byte[] Picture { get; set; } = null!;

        public virtual OrderEntity? Order { get; set; }
    }

    public enum Category {
        Postres,
        Bebidas,
        Snacks
    }

}
