using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Data;
using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Messages;

namespace CoffeeShopApi.Domain.UseCases.ClientUseCases
{
    public static class ClienteUpdateUseCase
    {
        public async static Task<bool> ClientUpdate(int Id, ClientInsertDTO clientInsert,IUnitOfWork unitOfWork)
        {
            var client = await unitOfWork.ClientRepository.GetById(Id);

            if (client == null) throw new NotFoundException(ClientMessages.ClientByIdNotFound());

            client.Ci = clientInsert.Ci;
            client.ClientLastName = clientInsert.ClientLastName;
            client.ClientName = clientInsert.ClientName;

            unitOfWork.ClientRepository.Update(client);
            await unitOfWork.Save();
            return true;
        }
    }
}
