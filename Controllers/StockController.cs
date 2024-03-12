using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Stock;
using API.Helpers;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Этот код представляет контроллер StockController, который обрабатывает HTTP-запросы, связанные с акциями.
namespace API.Controllers
{
    // это атрибут маршрутизации, который указывает, что все HTTP-запросы к этому контроллеру должны начинаться с /api/stock.
    [Route("api/stock")]
    // это атрибут, который указывает, что контроллер является контроллером API.
    [ApiController]

    //---------------
    // ControllerBase - это базовый класс в ASP.NET Core для контроллеров, который предоставляет базовую функциональность для обработки HTTP запросов. Он является частью пространства имен Microsoft.AspNetCore.Mvc, и его используют для создания пользовательских контроллеров веб-приложений.
    public class StockController : ControllerBase
    {
        //-------------
        // это поле, которое представляет контекст базы данных ApplicationDBContext. Он будет использоваться для доступа к данным о акциях.
        private readonly ApplicationDBContext _context;
        // это поле, которое представляет репозиторий акций IStockRepository. Репозиторий используется для выполнения операций чтения и записи данных о акциях.
        private readonly IStockRepository _stockRepo;

        //----------------
        // это конструктор контроллера, который принимает экземпляры контекста базы данных и репозитория акций.
        public StockController(ApplicationDBContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
        }

        //------------------
        // это атрибут, который указывает, что метод обрабатывает HTTP GET запросы.
        [HttpGet]
        // это метод, который возвращает все акции.
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // это вызов асинхронного метода GetAllAsync() репозитория акций для получения всех акций из базы данных.
            var stocks = await _stockRepo.GetAllAsync(query);

            // это преобразование полученных акций в DTO (Data Transfer Object). Здесь используется метод ToStockDto(), который преобразует акцию в объект DTO.
            var stockDto = stocks.Select(s => s.ToStockDto());

            // это возврат успешного HTTP-ответа с кодом 200 и списком акций.
            return Ok(stockDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        //-------------------
        [HttpPost]
        // это метод, который принимает объект DTO CreateStockRequestDto в качестве параметра из тела запроса. DTO используется для передачи данных о новой акции от клиента к серверу.
        // Атрибут [FromBody] указывает ASP.NET Core, что необходимо прочитать тело запроса и использовать его для создания объекта CreateStockRequestDto.
        // stockDto - это имя переменной, которая является параметром метода Create контроллера.В данном контексте, это объект, который содержит данные о новой акции, переданные клиентом в теле HTTP-запроса.
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // этот код вызывает метод расширения ToStockFromCreateDto(), который преобразует объект DTO CreateStockRequestDto в объект модели Stock. Таким образом, создается новый объект модели Stock на основе данных, полученных от клиента.
            var stockModel = stockDto.ToStockFromCreateDto();
            // этот код вызывает асинхронный метод CreateAsync(stockModel) репозитория акций для добавления новой акции в базу данных.
            await _stockRepo.CreateAsync(stockModel);
            // это возврат успешного HTTP ответа с кодом 201 "Создано". Метод CreatedAtAction создает ответ, который указывает на действие GetById (действие для получения акции по ее идентификатору) и передает идентификатор новой акции. В ответе также передается объект DTO StockDto, который представляет новую акцию. Таким образом, клиент получает информацию о том, что акция была успешно создана, и ее данные.
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        //------------------
        [HttpPut]
        [Route("{id:int}")]
        //это метод контроллера, который принимает два параметра: id из маршрута (идентификатор акции, которую нужно обновить) и updateDto из тела HTTP запроса (DTO для обновления информации об акции).
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // это вызов асинхронного метода _stockRepo.UpdateAsync, который обновляет информацию об акции в базе данных на основе переданных данных в объекте updateDto.
            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = await _stockRepo.DeleteAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            //  это возврат успешного HTTP-ответа с кодом 204 "Содержимое отсутствует", что указывает на успешное выполнение операции удаления без возвращения данных в ответе.
            return NoContent();
        }
    }
}