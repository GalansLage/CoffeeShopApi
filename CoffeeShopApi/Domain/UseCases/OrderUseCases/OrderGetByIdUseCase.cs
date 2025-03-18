using CoffeeShopApi.Data;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Mappers;
using CoffeeShopApi.Utils.Messages;

namespace CoffeeShopApi.Domain.UseCases.OrderUseCases
{
    public static class OrderGetByIdUseCase
    {
        public async static Task<OrderDTO> OrderGetById(int Id,IUnitOfWork unitOfWork)
        {
            var order = await unitOfWork.OrderRepository.GetById(Id);

            if (order == null) throw new NotFoundException(OrderMessages.OrderByIdNotFound());

            return OrderMapper.ToDTO(order);
        }
    }
}
