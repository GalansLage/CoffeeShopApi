using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;

namespace CoffeeShopApi.Utils.Mappers
{
    public static class ClientMapper
    {
        public static ClientDTO ToDTO(ClientEntity client)
            => new ClientDTO
            {
                Id = client.Id,
                ClientName = client.ClientName,
                ClientLastName = client.ClientLastName,
                Ci = client.Ci,
                Order = OrderMapper.ToDTO(client.Order!)
            };
    }
}
