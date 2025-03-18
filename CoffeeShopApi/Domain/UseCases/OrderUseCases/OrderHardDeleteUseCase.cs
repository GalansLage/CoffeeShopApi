using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain.UseCases.OrderUseCases
{
    public static class OrderHardDeleteUseCase
    {
        public async static Task<bool> OrderHardDelete(int Id,IUnitOfWork unitOfWork)
        {
            await unitOfWork.OrderRepository.HardDelete(Id);
            await unitOfWork.Save();
            return true;
        }
    }
}
