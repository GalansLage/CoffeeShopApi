using CoffeeShopApi.Data.Entities;

namespace CoffeeShopApi.Data.Repositories
{
    public interface IOrderRepository : IGenericRepository<OrderEntity, int>
    {
        IQueryable<OrderEntity> GetByState(State state);

    }

    public class OrderRepository : GenericRepository<OrderEntity, int>, IOrderRepository
    {
        public OrderRepository(CoffeeShopContext context) : base(context)
        {
        }

        public IQueryable<OrderEntity> GetByState(State state)
        => Entities.Where(o => o.State.Equals(state));
    }
}
