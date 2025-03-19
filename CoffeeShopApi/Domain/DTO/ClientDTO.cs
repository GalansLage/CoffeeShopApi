using CoffeeShopApi.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Domain.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string ClientName { get; set; } = null!;

        [MaxLength(25)]
        public string ClientLastName { get; set; } = null!;

        [MaxLength(11)]
        public string Ci { get; set; } = null!;

        public OrderDTO Order { get; set; } = new OrderDTO();
    }

    public class ClientsApiResponse
    {
        public string? Response { get; set; }
        public int StatusRequest { get; set; }
        public List<ClientDTO> Clients { get; set; }
    } 
    
    public class ClientApiResponse
    {
        public string? Response { get; set; }
        public int StatusRequest { get; set; }
        public ClientDTO Client { get; set; }
    }
    
    public class NoApiResponse
    {
        public string? Response { get; set; }
        public int StatusRequest { get; set; }
        public ClientDTO Client { get; set; }
    }
}
