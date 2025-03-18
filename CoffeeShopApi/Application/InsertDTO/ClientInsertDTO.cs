using System.ComponentModel.DataAnnotations;
using CoffeeShopApi.Data.Entities;

namespace CoffeeShopApi.Application.InsertDTO
{
    public class ClientInsertDTO
    {
        [MaxLength(25)]
        public string ClientName { get; set; } = null!;

        [MaxLength(25)]
        public string ClientLastName { get; set; } = null!;

        [MaxLength(11)]
        public string Ci { get; set; } = null!;

        
    }
}
