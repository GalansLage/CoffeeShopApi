using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Data.Entities
{
    public class ClientEntity:BaseEntity
    {
        [MaxLength(25)]
        public string ClientName { get; set; } = null!;

        [MaxLength(25)]
        public string ClientLastName { get; set; } = null!;

        [MaxLength(11)]
        public string Ci { get; set; } = null!;

        public virtual OrderEntity? Order { get; set; }
    }
}
