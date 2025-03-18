using CoffeeShopApi.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Application.InsertDTO
{
    public class ProductInsertDTO
    {
        [Required]
        [MaxLength(25)]
        public string ProductName { get; set; } = null!;

        [Required]
        [MaxLength(125)]
        public string Description { get; set; } = null!;

        [Required]
        public Category Category { get; set; }

        [Required]
        public int Availability { get; set; } = 0;

        [Required]
        public decimal Price { get; set; } = 0;

    }
}
