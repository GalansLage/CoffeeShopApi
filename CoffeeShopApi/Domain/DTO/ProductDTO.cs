using CoffeeShopApi.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Domain.DTO
{
    public class ProductDTO
    {
        [MaxLength(25)]
        public string ProductName { get; set; } = null!;

        [MaxLength(125)]
        public string Description { get; set; } = null!;

        [MaxLength(25)]
        public Category Category { get; set; }

        public int Availability { get; set; } = 0;

        public int Price { get; set; } = 0;

        public byte[] Picture { get; set; } = null!;
    }
}
