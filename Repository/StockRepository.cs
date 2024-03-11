using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Stock;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Repository
{
    // Этот код представляет класс StockRepository, который реализует интерфейс IStockRepository. Этот класс предоставляет методы для выполнения операций CRUD (Create, Read, Update, Delete) с данными об акциях в базе данных.
    public class StockRepository : IStockRepository
    {
        // это поле класса, которое представляет контекст базы данных, необходимый для взаимодействия с данными.
        private readonly ApplicationDBContext _context;
        // это конструктор класса, который принимает контекст базы данных в качестве параметра и инициализирует поле _context.
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //-------------
        // Метод CreateAsync добавляет новую акцию в базу данных, используя метод AddAsync для добавления объекта Stock в набор сущностей Stocks, а затем вызывает SaveChangesAsync для сохранения изменений в базе данных.
        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        //--------------
        // Метод DeleteAsync удаляет акцию из базы данных по её идентификатору. Сначала он находит акцию по идентификатору с помощью FirstOrDefaultAsync, затем, если акция найдена, удаляет её из контекста базы данных и вызывает SaveChangesAsync для сохранения изменений.
        public async Task<Stock?> DeleteAsync(int id)
        {
            // Метод FirstOrDefaultAsync используется для асинхронного поиска первого элемента, удовлетворяющего заданным критериям, в последовательности объектов. Если элемент найден, метод возвращает этот элемент, иначе возвращает значение по умолчанию для типа элементов в последовательности (например, null для ссылочных типов).
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

//----------------
        // Метод GetAllAsync возвращает список всех акций из базы данных, вызывая метод ToListAsync.
        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        //----------------
        // Метод GetByIdAsync возвращает акцию по её идентификатору из базы данных, используя метод FindAsync.
        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }


        //----------------
        // Метод UpdateAsync обновляет информацию об акции в базе данных. Сначала он находит акцию по её идентификатору с помощью FirstOrDefaultAsync, затем обновляет свойства акции с информацией из объекта DTO UpdateStockRequestDto и вызывает SaveChangesAsync для сохранения изменений.
        public async Task<Stock> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.LastDiv = stockDto.LastDiv;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();

            return existingStock;
        }
    }
}