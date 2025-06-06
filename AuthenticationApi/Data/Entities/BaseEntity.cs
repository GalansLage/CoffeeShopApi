using System.ComponentModel.DataAnnotations;

namespace AuthenticationApi.Data.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime DeletedTimeUtc { get; set; }

        [ConcurrencyCheck]
        public DateTime LastUpdateUtc { get; set; }
    }
}
