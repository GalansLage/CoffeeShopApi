using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;

namespace CoffeeShopApi.Utils.Mappers
{
    public static class ClientMapper
    {
        public static ClientDTO ToDTO(ClientEntity client)
            => new ClientDTO
            {
                ClientName = client.ClientName,
                ClientLastName = client.ClientLastName,
                Ci = client.Ci,
                Order = client.Order
            };
    }
}
