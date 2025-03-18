namespace CoffeeShopApi.Data.Entities
{
    public class OrderEntity:BaseEntity<int>
    {
        public DateTime OrderTime { get; set; }

        public virtual int? ClientId { get;set; }

        public State State { get; set; }

        public int TotalPay { get; set; } = 0;

        public int TotalPaid { get; set; } = 0;

        public PaymentMethod Payment { get; set; }

        public virtual ClientEntity? Client { get; set; }

        public virtual List<ProductEntity> Products { get; set; } = [];
    }

    public enum PaymentMethod
    {
        Efectivo,
        Tranferencia
    }
    public enum State
    {
        Pendiente,
        Completado,
        Cancelado
    }

}
