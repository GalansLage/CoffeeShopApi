using CoffeeShopApi.Data;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Mappers;
using CoffeeShopApi.Utils.Messages;

namespace CoffeeShopApi.Domain.UseCases.ProductsUseCases
{
    public static class GetProductByIdUseCase
    {
        public async static Task<ProductDTO> GetById(int id,IUnitOfWork unitOfWork)
        {
            var product = await unitOfWork.ProductRepository.GetById(id);

            if (product == null) throw new NotFoundException(ProductMessages.ProductByIdNotFound());

            return ProductMapper.ToDTO(product);
        }
    }
}
