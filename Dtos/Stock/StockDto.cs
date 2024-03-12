using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Comment;

// Этот код представляет класс StockDto, который является объектом передачи данных (DTO) для акций.
namespace API.Dtos.Stock
{
    // Класс StockDto предназначен для передачи информации о акциях между различными частями приложения, такими как контроллеры и представления. Это позволяет отделить модель данных, используемую для взаимодействия с базой данных, от модели данных, используемой для представления и передачи информации по HTTP запросам.
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = "";
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}