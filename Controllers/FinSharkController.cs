using FINSHARK.Data;
using FINSHARK.Dtos.Stock;
using FINSHARK.Interfaces;
using FINSHARK.Mappers;
using FINSHARK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FINSHARK.Controllers
{
    [Route("api/finshark")]
    [ApiController]
    public class FinSharkController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IStock _repo;

        public FinSharkController(ApplicationDBContext dBContetxt, IStock repo)
        {
            _dbContext = dBContetxt;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStock()
        {
            var stockModel = await _repo.GetAllStock();
            var stockDTO = stockModel.Select(s => s.ToStockDTO());
            return Ok(stockDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById(int id)
        {

            return Ok(await _repo.GetStockById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock(CreateStockDTO createStockDTO)
        {
            var createModel = createStockDTO.ToStockModel();

            await _repo.CreateStock(createModel);
            return CreatedAtAction(nameof(GetStockById), new { Id = createModel.Id }, createStockDTO.ToStockModel());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int id, UpdateStockDTO updateStockDTO)
        {
            await _repo.UpdateStock(id, updateStockDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await _repo.DeleteStock(id);
            return Ok();
        }
    }
}
