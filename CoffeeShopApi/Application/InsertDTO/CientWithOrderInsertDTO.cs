using System.ComponentModel.DataAnnotations;
using CoffeeShopApi.Data.Entities;

namespace CoffeeShopApi.Application.InsertDTO
{
    public class CientWithOrderInsertDTO
    {
        [Required]
        [MaxLength(25)]
        public string ClientName { get; set; } = null!;

        [Required]
        [MaxLength(25)]
        public string ClientLastName { get; set; } = null!;

        [Required]
        [MaxLength(11)]
        public string Ci { get; set; } = null!;

        [Required]
        public PaymentMethod Payment { get; set; }
    }
}
