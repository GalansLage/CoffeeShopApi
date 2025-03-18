using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Entities;

namespace CoffeeShopApi.Domain.UseCases.ProductsUseCases
{
    public static class InsertProductUseCase
    {
        public async static Task<ProductEntity> InsertProduct(ProductInsertDTO product,IUnitOfWork unitOfWork)
        {
            var moneyPrice = new MoneyEntity(product.Price);

            ProductEntity productEntity = new()
            {
                Availability = product.Availability,
                Category = product.Category,
                Description = product.Description,
                Price = moneyPrice.Cents,
                ProductName = product.ProductName,
                Picture = []
            };

            unitOfWork.ProductRepository.Update(productEntity);
            await unitOfWork.Save();

            return productEntity;

        }
    }
}
