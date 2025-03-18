using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain.UseCases.OrderUseCases
{
    public static class OrderSoftDeleteUseCase
    {
        public async static Task<bool> OrderSoftDelete(int Id,IUnitOfWork unitOfWork)
        {
            var order = await unitOfWork.OrderRepository.GetById(Id);
            order!.State = Data.Entities.State.Completado;
            unitOfWork.OrderRepository.Update(order);
            await unitOfWork.OrderRepository.SoftDelete(Id);
            await unitOfWork.Save();
            return true;
        }
    }
}
