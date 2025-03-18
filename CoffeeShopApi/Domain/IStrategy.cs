using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain
{
    public interface IStrategy<T,Tid,TInsert,TEn>
    {
        Task<List<T>> GetAll(int pageNumber,int pageSize);
        Task<T> GetById(Tid Id);
        Task<TEn> Insert(TInsert value);
        Task<bool> SoftDelete(Tid Id);
        Task<bool> HardDelete(Tid Id);
        Task<bool> Update(Tid Id,TInsert value);
    }
}
