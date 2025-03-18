using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain.UseCases.ClientUseCases
{
    public static class ClientHardDeleteUseCase
    {
        public async static Task<bool> ClientHardDelete(int Id,IUnitOfWork unitOfWork)
        {
            await unitOfWork.ClientRepository.HardDelete(Id);
            await unitOfWork.Save();
            return true;
        }
    }
}
