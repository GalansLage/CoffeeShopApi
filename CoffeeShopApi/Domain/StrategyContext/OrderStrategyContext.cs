using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Domain.UseCases.ClientUseCases;
using CoffeeShopApi.Domain.UseCases.OrderUseCases;

namespace CoffeeShopApi.Domain.StrategyContext
{
    public class OrderStrategyContext : IStrategy<OrderDTO, int, OrderInsertDTO, OrderEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderStrategyContext(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderDTO>> GetAll(int pageNumber, int pageSize)
        => await OrderGetAllUseCase.OrderGetAll(pageNumber, pageSize, _unitOfWork);

        public async Task<OrderDTO> GetById(int Id)
        => await OrderGetByIdUseCase.OrderGetById(Id, _unitOfWork);

        public async Task<bool> HardDelete(int Id)
        => await OrderHardDeleteUseCase.OrderHardDelete(Id, _unitOfWork);

        public async Task<bool> SoftDelete(int Id)
        => await OrderSoftDeleteUseCase.OrderSoftDelete(Id, _unitOfWork);

        public Task<bool> Update(int Id, OrderInsertDTO value)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddProduct(int Id, int productId)
        => await OrderAddProductUseCase.OrderAddProduct(Id, productId, _unitOfWork);

        public async Task<bool> DeleteProduct(int Id, int productId)
        => await OrderDeleteProductUseCase.OrderDeleteProduct(Id, productId, _unitOfWork);

        public Task<OrderEntity> Insert(OrderInsertDTO value)
        {
            throw new NotImplementedException();
        }
    }
}
