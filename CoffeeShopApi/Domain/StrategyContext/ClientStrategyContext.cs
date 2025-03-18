using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Domain.UseCases.ClientUseCases;

namespace CoffeeShopApi.Domain.StrategyContext
{
    public class ClientStrategyContext : IStrategy<ClientDTO, int, ClientInsertDTO, ClientEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientStrategyContext(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<ClientDTO>> GetAll(int pageNumber, int pageSize)
        => ClientGetAllUseCase.ClientGetAll(pageNumber, pageSize, _unitOfWork);

        public Task<ClientDTO> GetById(int Id)
        => ClientGetByIdUseCase.CLientGetById(Id, _unitOfWork);

        public Task<bool> HardDelete(int Id)
        => ClientHardDeleteUseCase.ClientHardDelete(Id, _unitOfWork);

        public Task<bool> SoftDelete(int Id)
        => ClientSoftDeleteUseCase.ClientSoftDelete(Id, _unitOfWork);

        public Task<bool> Update(int Id, ClientInsertDTO value)
        => ClienteUpdateUseCase.ClientUpdate(Id, value, _unitOfWork);

        public Task<List<ClientDTO>> GetAllWithOrders(int pageNumber, int pageSize)
        => ClientGetAllWithOrderUseCase.ClientGetAllWithOrder(pageNumber, pageSize, _unitOfWork);

        public async Task<ClientEntity> InsertClientWithOrder(CientWithOrderInsertDTO cientWithOrderInsertDTO)
        => await InsertClientWithOrderUseCase.InsertClientWithOrder(cientWithOrderInsertDTO, _unitOfWork);

        public Task<ClientEntity> Insert(ClientInsertDTO value)
        {
            throw new NotImplementedException();
        }
    }
}
