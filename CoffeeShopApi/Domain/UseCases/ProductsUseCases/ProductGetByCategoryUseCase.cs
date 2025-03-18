using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Utils.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Domain.UseCases.ProductsUseCases
{
    public static class ProductGetByCategoryUseCase
    {
        public async static Task<List<ProductDTO>> ProductGetByCategory(Category category,IUnitOfWork unitOfWork)
        {
            var products = await unitOfWork.ProductRepository.GetByCategory(category).ToListAsync();

            List<ProductDTO> productsDTO = new List<ProductDTO>();

            foreach (var product in products)
            {
                productsDTO.Add(ProductMapper.ToDTO(product));
            }

            return productsDTO;
        }
    }
}
