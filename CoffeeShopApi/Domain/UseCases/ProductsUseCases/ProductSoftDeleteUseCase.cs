using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain.UseCases.ProductsUseCases
{
    public static class ProductSoftDeleteUseCase
    {
        public async static Task<bool> ProductSoftDelete(int id, IUnitOfWork unitOfWork)
        {
            await unitOfWork.ProductRepository.SoftDelete(id);
            await unitOfWork.Save();

            return true;
        } 
    }
}
