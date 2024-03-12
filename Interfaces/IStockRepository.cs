using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Stock;
using API.Helpers;
using API.Models;


namespace API.Interfaces
{
    //Этот код определяет интерфейс IStockRepository, который представляет собой контракт для работы с данными о акциях в приложении. Этот интерфейс определяет методы, которые должны быть реализованы классом, представляющим репозиторий акций.
    public interface IStockRepository
    {
        // метод для получения всех акций. Возвращает список всех акций в виде объекта List<Stock>.
        Task<List<Stock>> GetAllAsync(QueryObject query);
        // метод для получения акции по её идентификатору. Возвращает объект акции с указанным идентификатором. Если акция не найдена, возвращает null.
        Task<Stock?> GetByIdAsync(int id);
        // метод для создания новой акции. Принимает объект модели акции Stock в качестве параметра и возвращает созданный объект акции.
        Task<Stock> CreateAsync(Stock stockModel);
        // метод для обновления информации о существующей акции. Принимает идентификатор акции и объект DTO UpdateStockRequestDto, содержащий обновленную информацию об акции. Возвращает обновленный объект акции.
        Task<Stock> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        // метод для удаления акции по её идентификатору. Принимает идентификатор акции в качестве параметра и возвращает удаленный объект акции. Если акция не найдена, возвращает null.
        Task<Stock?> DeleteAsync(int id);
        
        Task<bool> StockExists(int id);
    }
}

// Этот интерфейс определяет абстракцию для доступа к данным о акциях, а его реализация позволяет работать с этими данными через конкретный источник данных, такой как база данных.