using System.ComponentModel.DataAnnotations.Schema;

namespace FINSHARK.Dtos.Stock
{
    public class UpdateStockDTO
    {
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}
