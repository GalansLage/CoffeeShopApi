using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Messages;

namespace CoffeeShopApi.Data.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductEntity, int>
    {
        IQueryable<ProductEntity> GetByCategory(Category category);
        IQueryable<ProductEntity> FilterByName(string name);
    }

    public class ProductRepository : GenericRepository<ProductEntity, int>, IProductRepository
    {
        public ProductRepository(CoffeeShopContext context) : base(context)
        {
        }

        public  IQueryable<ProductEntity> FilterByName(string name)
        {
            var products = Entities.Where(p=>p.ProductName.Contains(name));

            return products == null ? throw new NotFoundException(ProductMessages.ProductByIdNotFound()) : products;
        }

        public IQueryable<ProductEntity> GetByCategory(Category category)=>
            Entities.Where(p => p.Category.Equals(category));
        
    }
}
