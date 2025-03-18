using CoffeeShopApi.Data;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Mappers;
using CoffeeShopApi.Utils.Messages;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Domain.UseCases.OrderUseCases
{
    public static class OrderGetAllUseCase
    {
        public async static Task<List<OrderDTO>> OrderGetAll(int pageNumber,int pageSize,IUnitOfWork unitOfWork)
        {
            var orders = await unitOfWork.OrderRepository.GetAll().ToListAsync();


            List<OrderDTO> ordersDTO = new List<OrderDTO>();

            if (!orders.Any()) throw new NotFoundException(OrderMessages.OrderNotFound());

            foreach (var order in orders)
            {
                ordersDTO.Add(OrderMapper.ToDTO(order));
            }

            return ordersDTO.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
