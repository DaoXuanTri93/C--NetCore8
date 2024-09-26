using FINSHARK.Dtos.Stock;
using FINSHARK.Models;
using Microsoft.AspNetCore.Mvc;

namespace FINSHARK.Interfaces
{
    public interface IStock
    {
        Task<List<Stock>> GetAllStock();
        Task<Stock?> GetStockById(int id);
        Task<Stock> CreateStock(Stock stock);
        Task<Stock> UpdateStock(int id, UpdateStockDTO updateStockDTO);
        Task<Stock?> DeleteStock(int id);
        Task<bool> CheckExists(int id);
    }
}
