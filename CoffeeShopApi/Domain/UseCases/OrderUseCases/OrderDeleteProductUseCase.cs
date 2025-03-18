using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain.UseCases.OrderUseCases
{
    public static class OrderDeleteProductUseCase
    {
        public async static Task<bool> OrderDeleteProduct(int Id,int productId,IUnitOfWork unitOfWork)
        {
            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await unitOfWork.OrderRepository.DeleteProduct(Id, productId);
                    await unitOfWork.CommitAsync();
                    return true;
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Ocurrio un error al insertar la orden.", ex);
                }
            }
                
        }
    }
}
