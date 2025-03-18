using CoffeeShopApi.Data;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Mappers;
using CoffeeShopApi.Utils.Messages;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Domain.UseCases.ClientUseCases
{
    public static class ClientGetAllUseCase
    {
        public async static Task<List<ClientDTO>> ClientGetAll(int pageNumber,int pageSize,IUnitOfWork unitOfWork)
        {
            var clients = await unitOfWork.ClientRepository.GetAll().ToListAsync();

            var clientsDTO = new List<ClientDTO>();

            if (!clients.Any()) throw new NotFoundException(ClientMessages.CLientNotFound());

            foreach (var client in clients)
            {
                clientsDTO.Add(ClientMapper.ToDTO(client!));
            }

            return clientsDTO.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        } 
    }
}
