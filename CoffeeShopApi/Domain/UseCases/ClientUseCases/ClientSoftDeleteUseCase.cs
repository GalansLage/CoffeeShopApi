using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain.UseCases.ClientUseCases
{
    public static class ClientSoftDeleteUseCase
    {
        public async static Task<bool> ClientSoftDelete(int Id,IUnitOfWork unitOfWork)
        {
            await unitOfWork.ClientRepository.SoftDelete(Id);
            await unitOfWork.Save();
            return true;
        } 
    }
}
