using CoffeeShopApi.Application.InsertDTO;
using CoffeeShopApi.Data.Entities;
using CoffeeShopApi.Domain.DTO;
using CoffeeShopApi.Domain.StrategyContext;
using CoffeeShopApi.Utils.Exeptions;
using CoffeeShopApi.Utils.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly ProductStrategyContext _strategyContext;

        public ProductController(ProductStrategyContext strategyContext)
        {
            _strategyContext = strategyContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts(int pageNumber, int pageSize)
        {
            try
            {
                return Ok(ApiResponse<ProductDTO>.Success(await _strategyContext.GetAll(pageNumber, pageSize)));
            }
            catch(NotFoundException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int Id)
        {
            try
            {
                return Ok(ApiResponse<ProductDTO>.Success(await _strategyContext.GetById(Id)));
            }
            catch(NotFoundException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(ProductInsertDTO insertDTO)
        {
            var product = await _strategyContext.Insert(insertDTO);

            return CreatedAtAction(nameof(GetProductById), new { Id = product.Id }, ProductMapper.ToDTO(product));
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> PutProduct(int Id, ProductInsertDTO productInsert)
        {
            try
            {
                await _strategyContext.Update(Id, productInsert);
                return NoContent();
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("HardDlete/{Id}")]
        public async Task<ActionResult> HardDeleteProduct(int Id)
        {
            try
            {
                await _strategyContext.HardDelete(Id);
                return NoContent();
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("SoftDelete/{Id}")]
        public async Task<ActionResult> SoftDeleteProduct(int Id)
        {
            try
            {
                await _strategyContext.SoftDelete(Id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetByCategory")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetByCategory(Category category)
        {
            try
            {
                return Ok(ApiResponse<ProductDTO>.Success(await _strategyContext.FilterByCategory(category)));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetByProductName")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetByProductName(string productName)
        {
            try
            {
                return Ok(ApiResponse<ProductDTO>.Success(await _strategyContext.FilterByName(productName)));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
