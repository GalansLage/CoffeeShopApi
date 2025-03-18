using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Messages;

namespace CoffeeShopApi.Domain.UseCases.ProductsUseCases
{
    public static class ProductUpdateUseCase
    {
        public async static Task<bool> ProductUpdate(int id, ProductInsertDTO productInsertDTO, IUnitOfWork unitOfWork)
        {
            var product = await unitOfWork.ProductRepository.GetById(id);
            var moneyPrice = new MoneyEntity(productInsertDTO.Price);
            if (product == null) throw new NotFoundException(ProductMessages.ProductByIdNotFound());

            product.Availability = productInsertDTO.Availability;
            product.Category = productInsertDTO.Category;
            product.Description = productInsertDTO.Description;
            product.Price = moneyPrice.Cents;
            product.ProductName = productInsertDTO.ProductName;

            unitOfWork.ProductRepository.Update(product);
            await unitOfWork.Save();

            return true;
        }
    }
}
