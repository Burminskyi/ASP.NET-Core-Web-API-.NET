using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol can't be over 10 characters")]
        public string Symbol { get; set; } = "";
        [Required]
        [MaxLength(30, ErrorMessage = "Company name can't be over 30 characters")]
        public string CompanyName { get; set; } = "";
        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Industry can't be over 20 characters")]
        public string Industry { get; set; } = "";
        [Required]
        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}