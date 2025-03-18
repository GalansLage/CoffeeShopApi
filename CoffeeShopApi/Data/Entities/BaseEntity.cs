using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Data.Entities
{
    public class BaseEntity<Tid>
    {
        public Tid Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedTimeUtc { get; set; }

        [ConcurrencyCheck]
        public DateTime LastUpdateUtc { get; set; }

    }
}
