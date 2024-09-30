using FINSHARK.Data;
using FINSHARK.Dtos.Stock;
using FINSHARK.Helper;
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
            return await _context.Stock.AnyAsync(x => x.Id == id);
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

        public async Task<List<Stock>> GetAllStock(QueryObject query)
        {

            var stock = _context.Stock.Include(s => s.Comments).AsQueryable(); ;
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stock = stock.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrEmpty(query.Purchase.ToString()))
            {
                stock = stock.Where(s => s.Purchase.ToString().Contains(query.Purchase.ToString()!));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase))
                {
                    stock = query.IsDecsending ? stock.OrderByDescending(s => s.CompanyName) : stock.OrderBy(s => s.CompanyName);
                }

                if (query.SortBy.Equals("MarketCap", StringComparison.OrdinalIgnoreCase))
                {
                    stock = query.IsDecsending ? stock.OrderByDescending(s => s.MarketCap) : stock.OrderBy(s => s.MarketCap);
                }
            }
            // number 1 và size 2
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            

            return await stock.Skip(skipNumber).Take(query.PageSize).ToListAsync();


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
