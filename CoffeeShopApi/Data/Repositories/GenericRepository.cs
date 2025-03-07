using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Utils.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Data.Repositories
{
    public interface IGenericRepository<T, Tid>
    {
        IQueryable<T?> GetAll();
        Task<T?> GetById(Tid Id);
        Task<T> Insert(T value);
        Task<bool> SoftDelete(Tid Id);
        Task<bool> HardDelete(Tid Id);
        bool Update(T value);

    }

    public abstract class GenericRepository<T, Tid> : IGenericRepository<T, Tid>
        where T: BaseEntity<Tid>
        where Tid: IEquatable<Tid>
    {
        protected readonly CoffeeShopContext _context;
        protected DbSet<T> Entities => _context.Set<T>();

        protected GenericRepository(CoffeeShopContext context)
        {
            _context = context;
        }


        public IQueryable<T?> GetAll()
        =>Entities;

        public async Task<T?> GetById(Tid Id)
        => await Entities.FirstOrDefaultAsync(e => e.Id.Equals(Id));
        public async Task<bool> HardDelete(Tid Id)
        {
            var entity = await GetById(Id);

            if (entity == null) throw new NotFoundException();

            Entities.Remove(entity);

            return true;
        }

        public async Task<T> Insert(T value)
        {
            var result = await Entities.AddAsync(value);

            return result.Entity;
        }
        

        public async Task<bool> SoftDelete(Tid Id)
        {
            var entity = await GetById(Id);

            if (entity == null) throw new NotFoundException();

            entity.IsDeleted = true;
            entity.DeletedTimeUtc = DateTime.UtcNow;

            return Update(entity);
        }

        public bool Update(T value)
        {
            value.LastUpdateUtc = DateTime.UtcNow;
            Entities.Update(value);
            return true;
        }
    }
}
