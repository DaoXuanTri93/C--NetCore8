using FINSHARK.Data;
using FINSHARK.Dtos.Stock;
using FINSHARK.Interfaces;
using FINSHARK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FINSHARK.Repository
{
    public class StockRepository : IStock
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckExists(int id)

        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
            if (stockModel == null)
            {
                return false;
            }

            return true;
        }

        public async Task<Stock> CreateStock(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteStock(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;

        }

        public async Task<List<Stock>> GetAllStock()
        {
            return await _context.Stock.Include(s => s.Comments).ToListAsync();
        }

        public async Task<Stock?> GetStockById(int id)
        {
            var stockModel = await _context.Stock.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            return stockModel;
        }

        public async Task<Stock> UpdateStock(int id, UpdateStockDTO updateStockDTO)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            stockModel.Purchase = updateStockDTO.Purchase;
            stockModel.MarketCap = updateStockDTO.MarketCap;
            stockModel.Industry = updateStockDTO.Industry;
            stockModel.CompanyName = updateStockDTO.CompanyName;
            stockModel.LastDiv = updateStockDTO.LastDiv;

            await _context.SaveChangesAsync();

            return stockModel;
        }
    }
}
