using CoffeeShopApi.Data;

namespace CoffeeShopApi.Domain.UseCases.OrderUseCases
{
    public static class OrderAddProductUseCase
    {
        public async static Task<bool> OrderAddProduct(int Id,int productId,IUnitOfWork unitOfWork)
        {
            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await unitOfWork.OrderRepository.AddProduct(Id, productId);
                    await unitOfWork.CommitAsync();
                    return true;
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Ocurrio un error al insertar el producto en la orden.", ex);
                }
            }
                
            
        }
    }
}
