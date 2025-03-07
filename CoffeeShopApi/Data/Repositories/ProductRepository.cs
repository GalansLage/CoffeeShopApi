using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Utils.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Data.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductEntity, int>
    {
        IQueryable<ProductEntity> GetByCategory(Category category);
        Task<ProductEntity> FilterByName(string name);
    }

    public class ProductRepository : GenericRepository<ProductEntity, int>, IProductRepository
    {
        public ProductRepository(CoffeeShopContext context) : base(context)
        {
        }

        public async Task<ProductEntity> FilterByName(string name)
        {
            var product = await Entities.FirstOrDefaultAsync(p => p.ProductName.Equals(name));

            return product == null ? throw new NotFoundException() : product;
        }

        public IQueryable<ProductEntity> GetByCategory(Category category)=>
            Entities.Where(p => p.Category.Equals(category));
        
    }
}
