using FINSHARK.Dtos.Stock;
using FINSHARK.Models;

namespace FINSHARK.Mappers
{
    public static class StockMapper
    {
        public static StockDTO ToStockDTO(this Stock stockModel)
        {
            return new StockDTO
            {
                Id = stockModel.Id,
                CompanyName = stockModel.CompanyName,
                Industry = stockModel.Industry,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap,
                Purchase  = stockModel.Purchase,
                Comments = stockModel.Comments.Select(c => c.ToComment()).ToList(),

            };
        }

        public static Stock ToStockModel(this CreateStockDTO createStockDTO)
        {
            return new Stock
            {
                CompanyName = createStockDTO.CompanyName,
                Industry = createStockDTO.Industry,
                LastDiv = createStockDTO.LastDiv,
                MarketCap = createStockDTO.MarketCap,
                Purchase = createStockDTO.Purchase
            };
        }

        public static Stock ToStockUpdateModel(this UpdateStockDTO updateStockDTO)
        {
            return new Stock
            {
                CompanyName = updateStockDTO.CompanyName,
                Industry = updateStockDTO.Industry,
                LastDiv = updateStockDTO.LastDiv,
                MarketCap = updateStockDTO.MarketCap,
                Purchase = updateStockDTO.Purchase
            };
        }
    }
}
