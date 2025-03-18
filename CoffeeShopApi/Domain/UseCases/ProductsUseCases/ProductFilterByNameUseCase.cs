using CoffeeShopApi.Data;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Utils.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Domain.UseCases.ProductsUseCases
{
    public static class ProductFilterByNameUseCase
    {
        public async static Task<List<ProductDTO>> ProductFilterByName(string name,IUnitOfWork unitOfWork)
        {
            var products = await unitOfWork.ProductRepository.FilterByName(name).ToListAsync();

            List<ProductDTO> productsDTO = new List<ProductDTO>();

            foreach (var product in products)
            {
                productsDTO.Add(ProductMapper.ToDTO(product));
            }

            return productsDTO;
        } 
    }
}
