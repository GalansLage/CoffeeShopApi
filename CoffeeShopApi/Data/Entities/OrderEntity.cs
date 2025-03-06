namespace CoffeeShopApi.Data.Entities
{
    public class OrderEntity:BaseEntity
    {
        public DateTime OrderTime { get; set; }

        public virtual int? ClientId { get;set; }

        public State State { get; set; }

        public int TotalPay { get; set; } = 0;

        public int TotalPaid { get; set; } = 0;

        public PaymentMethod Payment { get; set; }

        public virtual ClientEntity? Client { get; set; }

        public virtual IEnumerable<ProductEntity> Products { get; set; } = [];
    }

    public enum PaymentMethod
    {
        Efectivo,
        Tranferencia
    }
    public enum State
    {
        Pendiente,
        Proceso,
        Completado,
        Cancelado
    }

}
