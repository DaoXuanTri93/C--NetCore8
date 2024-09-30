using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINSHARK.Dtos.Stock
{
    public class CreateStockDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Ít nhất phải 5 kí tự")]
        [MaxLength(10, ErrorMessage = "Tối đa là 10 kí tự")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(0.001, 100)]
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}
