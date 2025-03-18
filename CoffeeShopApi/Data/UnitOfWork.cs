using CoffeeShopApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoffeeShopApi.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IClientRepository ClientRepository { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task<int> Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoffeeShopContext _context;

        private IDbContextTransaction _transaction;
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

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
            return _transaction;
        }

        public async Task RollbackAsync()
        {
            if(_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction = null;
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }
       

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
