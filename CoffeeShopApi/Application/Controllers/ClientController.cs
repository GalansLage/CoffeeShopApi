using System.Formats.Asn1;
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
    public class ClientController:ControllerBase
    {
        private readonly ClientStrategyContext _strategy;

        public ClientController(ClientStrategyContext strategy)
        {
            _strategy = strategy;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ClientDTO>>> ClientGetAll(int pageNumber,int pageSize)
        {
            try
            {
                return Ok(await _strategy.GetAll(pageNumber, pageSize));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, "Ha ocurrido un error con la recuest");
            }
        }

        //[HttpGet("GetAllWithOrders")]
        //public async Task<ActionResult<List<ClientDTO>>> ClientGetAllWithOrders(int pageNumber, int pageSize)
        //{
        //    try
        //    {
        //        return Ok(await _strategy.GetAllWithOrders(pageNumber, pageSize));
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Data);
        //        return StatusCode(500, "Ha ocurrido un error con la recuest");
        //    }
        //}

        [HttpGet("{Id}")]
        public async Task<ActionResult<ClientDTO>> ClientGetById(int Id)
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
                return StatusCode(500, "Ha ocurrido un error con la recuest");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> InsertClientWithOrder(CientWithOrderInsertDTO clientInsert)
        {
            try
            {
                var client = await _strategy.InsertClientWithOrder(clientInsert);
                return CreatedAtAction(nameof(ClientGetById), new { client.Id }, ClientMapper.ToDTO(client));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, "Ha ocurrido un error con la recuest");
            }
        }

        [HttpDelete("HardDelete/{Id}")]
        public async Task<ActionResult> ClientHardDelete(int Id)
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
                return StatusCode(500, "Ha ocurrido un error con la recuest");
            }
        }

        [HttpDelete("SoftDelete/{Id}")]
        public async Task<ActionResult> ClientSoftDelete(int Id)
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
                return StatusCode(500, "Ha ocurrido un error con la recuest");
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> ClientPut(int Id,ClientInsertDTO clientInsert)
        {
            try
            {
                await _strategy.Update(Id, clientInsert);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Data);
                return StatusCode(500, "Ha ocurrido un error con la recuest");
            }
        }

    }
}
