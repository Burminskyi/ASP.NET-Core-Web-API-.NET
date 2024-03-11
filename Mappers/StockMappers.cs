using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Stock;
using API.Models;


// Этот код представляет статический класс StockMappers, который содержит метод расширения для преобразования модели Stock в объект StockDto.
namespace API.Mappers
{
    public static class StockMappers
    {
        //-------------------
        // это статический метод расширения, который принимает объект модели Stock в качестве параметра и возвращает объект StockDto.
        public static StockDto ToStockDto(this Stock stockModel)
        {
            // внутри метода создается новый объект StockDto, который заполняется данными из переданной модели Stock.
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }

        //------------------
        // Этот метод является методом расширения для объекта типа CreateStockRequestDto, который преобразует его в объект типа Stock.
        // Он принимает в качестве параметра объект stockDto типа CreateStockRequestDto и возвращает объект типа Stock.
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}


// мапперы используются для преобразования данных из одной модели в другую. В контексте веб-приложений и API часто используется преобразование данных из моделей (обычно используемых для работы с базой данных) в объекты DTO (Data Transfer Objects), которые предназначены для передачи данных по сети или между различными слоями приложения.
// Мапперы позволяют разделить модели данных, используемые внутри приложения (например, для работы с базой данных), от моделей данных, предназначенных для передачи по HTTP запросам или между различными слоями приложения. Это улучшает гибкость и разделение ответственности в приложении, а также упрощает сопровождение и тестирование кода.
// В частности, в вашем примере класс StockMappers содержит метод расширения ToStockDto, который выполняет преобразование объекта модели Stock в объект StockDto, который представляет собой упрощенную версию модели для передачи данных клиенту или другому слою приложения.
// Таким образом, мапперы действительно часто используются для переноса данных из модели в DTO и обратно, но их использование не ограничивается только этим. Они также могут выполнять другие преобразования данных в зависимости от потребностей приложения.





