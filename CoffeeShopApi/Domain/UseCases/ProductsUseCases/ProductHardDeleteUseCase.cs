using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain.UseCases.ProductsUseCases
{
    public static class ProductHardDeleteUseCase
    {
        public async static Task<bool> ProductHardDelete(int id, IUnitOfWork unitOfWork)
        {
            await unitOfWork.ProductRepository.HardDelete(id);
            await unitOfWork.Save();
            return true;
        }
    }
}
