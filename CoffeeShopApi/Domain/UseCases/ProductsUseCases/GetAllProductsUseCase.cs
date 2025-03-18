using CoffeeShopApi.Data;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Domain.StrategyContext;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Mappers;
using CoffeeShopApi.Utils.Messages;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Domain.UseCases.ProductsUseCases
{
    public static class GetAllProductsUseCase
    {
        public static async Task<List<ProductDTO>> GetProducts(int pageNumber, int pageSize, IUnitOfWork unitOfWork)
        {
            var products = await unitOfWork.ProductRepository.GetAll().ToListAsync();

            List<ProductDTO> productsDTO = new List<ProductDTO>();

           

            if (products.Any())
            {
                foreach (var product in products)
                {
                    productsDTO.Add(ProductMapper.ToDTO(product!));
                }
            }
            else
            {
                throw new NotFoundException(ProductMessages.ProductNotFound());
            }

            return productsDTO.Skip((pageNumber - 1)* pageSize).Take(pageSize).ToList();
        }
    }
}
