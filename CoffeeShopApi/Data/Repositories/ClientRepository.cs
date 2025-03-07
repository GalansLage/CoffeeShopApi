using CoffeeShopApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Data.Repositories
{
    public interface IClientRepository : IGenericRepository<ClientEntity, int>
    {
        IQueryable<ClientEntity> GetClientAndOrders();

    }
    public class ClientRepository : GenericRepository<ClientEntity, int>, IClientRepository
    {
        public ClientRepository(CoffeeShopContext context) : base(context)
        {
            
        }

        public IQueryable<ClientEntity> GetClientAndOrders()
        => _context.Clients.Include(c => c.Order);
    }
}
