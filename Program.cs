using API.Data;
using API.Interfaces;
using API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

//-------------------------
// В этом блоке кода происходит настройка инфраструктуры Entity Framework Core для работы с базой данных SQLite в ASP.NET Core приложении.
//этот метод добавляет сервис контекста базы данных ApplicationDBContext в контейнер зависимостей приложения. Этот контекст будет использоваться для взаимодействия с базой данных.
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    // это метод, который указывает Entity Framework Core использовать SQLite в качестве провайдера базы данных и задает строку подключения. В данном случае строка подключения извлекается из конфигурации приложения с помощью метода GetConnectionString("DefaultConnection").
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Этот код регистрирует зависимость между интерфейсом IStockRepository и его реализацией StockRepository в контейнере зависимостей приложения.
// AddScoped<IStockRepository, StockRepository>() означает, что каждый раз, когда в приложении запрашивается объект IStockRepository, контейнер зависимостей создает новый экземпляр класса StockRepository и предоставляет его.
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
