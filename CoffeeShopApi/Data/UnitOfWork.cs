using CoffeeShopApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IClientRepository ClientRepository { get; }
        Task<int> Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoffeeShopContext _context;
        public IProductRepository ProductRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IClientRepository ClientRepository { get; }

        public UnitOfWork(CoffeeShopContext context,IProductRepository productRepository,IOrderRepository orderRepository, IClientRepository clientRepository)
        {
            _context = context;
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
            ClientRepository = clientRepository;
        }
        public void Dispose()
        => _context.Dispose();
       

        public async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Conclicto de concurrencia");
            }

            return 0;
        }


    }
}
