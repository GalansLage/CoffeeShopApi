using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;

namespace CoffeeShopApi.Domain.UseCases.ClientUseCases
{
    public static class InsertClientWithOrderUseCase
    {
        public async static Task<ClientEntity> InsertClientWithOrder(CientWithOrderInsertDTO insertDTO,IUnitOfWork unitOfWork)
        {
            using(var transaction = unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    ClientEntity client = new ClientEntity
                    {
                        Ci = insertDTO.Ci,
                        ClientName = insertDTO.ClientName,
                        ClientLastName = insertDTO.ClientLastName
                    };

                    await unitOfWork.ClientRepository.Insert(client);

                    var order = new OrderEntity()
                    {
                        ClientId = client.Id,
                        OrderTime = DateTime.UtcNow,
                        Payment = insertDTO.Payment,
                        State = State.Pendiente,
                    };

                    await unitOfWork.OrderRepository.Insert(order);

                    client.Order = order;

                    await unitOfWork.CommitAsync();

                    return client;
                }
                catch(Exception ex)
                {
                    throw new ApplicationException("Ocurrio un error al insertar la orden.", ex);
                }
            }
        } 
    }
}
