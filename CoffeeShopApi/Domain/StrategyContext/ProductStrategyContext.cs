using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Domain.UseCases.ProductsUseCases;

namespace CoffeeShopApi.Domain.StrategyContext
{
    public class ProductStrategyContext : IStrategy<ProductDTO, int, ProductInsertDTO,ProductEntity>
    {
        protected readonly IUnitOfWork _unitOfWork;

        public ProductStrategyContext(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProductDTO>> GetAll(int pageNumber, int pageSize)
        => await GetAllProductsUseCase.GetProducts(pageNumber, pageSize, _unitOfWork);

        public async Task<ProductDTO> GetById(int Id)
        => await GetProductByIdUseCase.GetById(Id, _unitOfWork);

        public async Task<bool> HardDelete(int Id)
        =>await ProductHardDeleteUseCase.ProductHardDelete(Id, _unitOfWork);

        public async Task<ProductEntity> Insert(ProductInsertDTO productInsert)
        =>await InsertProductUseCase.InsertProduct(productInsert, _unitOfWork);

        public async Task<bool> SoftDelete(int Id)
        => await ProductSoftDeleteUseCase.ProductSoftDelete(Id, _unitOfWork);

        public async Task<bool> Update(int Id, ProductInsertDTO productInsert)
        => await ProductUpdateUseCase.ProductUpdate(Id, productInsert, _unitOfWork);

        public async Task<List<ProductDTO>> FilterByName(string name)
        => await ProductFilterByNameUseCase.ProductFilterByName(name, _unitOfWork);

        public async Task<List<ProductDTO>> FilterByCategory(Category category)
        => await ProductGetByCategoryUseCase.ProductGetByCategory(category, _unitOfWork);
    }
}
