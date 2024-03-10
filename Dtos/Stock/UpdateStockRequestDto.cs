using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        public string Symbol { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = "";
        public long MarketCap { get; set; }
    }
}