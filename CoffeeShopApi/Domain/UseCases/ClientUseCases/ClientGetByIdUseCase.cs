using CoffeeShopApi.Data;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Mappers;
using CoffeeShopApi.Utils.Messages;

namespace CoffeeShopApi.Domain.UseCases.ClientUseCases
{
    public static class ClientGetByIdUseCase
    {
        public async static Task<ClientDTO> CLientGetById(int Id,IUnitOfWork unitOfWork)
        {
            var client = await unitOfWork.ClientRepository.GetById(Id);

            if (client == null) throw new NotFoundException(ClientMessages.ClientByIdNotFound());

            return ClientMapper.ToDTO(client);
        }
    }
}
