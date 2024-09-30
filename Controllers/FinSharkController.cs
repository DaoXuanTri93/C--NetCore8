using FINSHARK.Data;
using FINSHARK.Dtos.Stock;
using FINSHARK.Helper;
using FINSHARK.Interfaces;
using FINSHARK.Mappers;
using FINSHARK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FINSHARK.Controllers
{
    [Route("api/finshark")]
    [ApiController]
    public class FinSharkController : ControllerBase
    {
        private readonly IStock _repo;

        public FinSharkController(IStock repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStock([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _repo.GetAllStock(query);
            var stockDTO = stockModel.Select(s => s.ToStockDTO());
            return Ok(stockDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            var stockModel = await _repo.GetStockById(id);
            if (stockModel == null) {
                return BadRequest("Stock does not exist");
            }

            return Ok(stockModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock(CreateStockDTO createStockDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
