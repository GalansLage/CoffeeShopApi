using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Domain.StrategyContext;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly OrderStrategyContext _strategy;

        public OrderController(OrderStrategyContext strategy)
        {
            _strategy = strategy;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders(int pageNumber,int pageSize)
        {
            try
            {
                return Ok(await _strategy.GetAll(pageNumber, pageSize));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<OrderDTO>> GetById(int Id)
        {
            try
            {
                return Ok(await _strategy.GetById(Id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, ex.Message);
            }
        }



        [HttpDelete("HardDelete/{Id}")]
        public async Task<ActionResult> CancelOrder(int Id)
        {
            try
            {
                await _strategy.HardDelete(Id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("SoftDelete/{Id}")]
        public async Task<ActionResult> OrderCompleted(int Id)
        {
            try
            {
                await _strategy.SoftDelete(Id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("AddProduct/{Id}/{productId}")]
        public async Task<ActionResult> AddProductToOrder(int Id,int productId)
        {
            try
            {
                await _strategy.AddProduct(Id, productId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch("DeleteProduct/{Id}/{productId}")]
        public async Task<ActionResult> DeleteProductToOrder(int Id, int productId)
        {
            try
            {
                await _strategy.DeleteProduct(Id, productId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
