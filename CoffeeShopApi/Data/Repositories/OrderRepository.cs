using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Messages;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Data.Repositories
{
    public interface IOrderRepository : IGenericRepository<OrderEntity, int>
    {
        IQueryable<OrderEntity> GetByState(State state);
        Task<bool> AddProduct(int Id, int productId);
        Task<bool> DeleteProduct(int Id, int productId);

    }

    public class OrderRepository : GenericRepository<OrderEntity, int>, IOrderRepository
    {
        public OrderRepository(CoffeeShopContext context) : base(context)
        {
        }

        public IQueryable<OrderEntity> GetByState(State state)
        => Entities.Where(o => o.State.Equals(state));

        public async Task<bool> AddProduct(int Id,int productId)
        {
            var order = await _context.Orders.Include(o => o.Products).FirstOrDefaultAsync(o => o.Id.Equals(Id));
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(productId));

            if (order == null) throw new NotFoundException(OrderMessages.OrderByIdNotFound());
            if (product == null) throw new NotFoundException(ProductMessages.ProductByIdNotFound());

            if (product.Availability < 1) throw new NotFoundException("No hay mas disponibilidad de este producto");

            product.Availability--;
            order.TotalPay += product.Price;

            if (order.Products.Any(p => p.Id == productId))
            {
                Console.WriteLine(order.Products.Count + "asfeagfqwegweg");
                _context.Products.Update(product);
                return true;
            }

            order.Products.Add(product);
            Console.WriteLine(order.Products.Count+"asfeagfqwegweg");
            product.OrderId = Id;

            return Update(order);
        }

        public async Task<bool> DeleteProduct(int Id, int productId)
        {
            var order = await _context.Orders.Include(o => o.Products).FirstOrDefaultAsync(o => o.Id.Equals(Id));
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(productId));

            if (order == null) throw new NotFoundException(OrderMessages.OrderByIdNotFound());
            if (product == null) throw new NotFoundException(ProductMessages.ProductByIdNotFound());
           
            if (order.Products.Any(p => p.Id == productId))
            {
                order.TotalPay -= product.Price;
                product.Availability++;
                _context.Products.Update(product);
                order.Products.Remove(product);
                return Update(order);
            }
            else
            {
                throw new NotFoundException("No exsiste ese producto en la orden");
            }
            
        }

    }
}
