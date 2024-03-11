using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    //-----------------
    // Этот код представляет класс ApplicationDBContext, который является наследником класса DbContext из Entity Framework Core. Класс DbContext является основным классом для работы с базой данных в Entity Framework Core.
    public class ApplicationDBContext : DbContext
    {
        //-----------------
        // это конструктор класса ApplicationDBContext, который принимает параметр DbContextOptions и передает его базовому конструктору класса DbContext. Этот конструктор используется для настройки контекста базы данных с помощью переданных опций.
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
        //-----------------
        //это свойства, представляющие наборы сущностей Stock и Comment, которые могут быть использованы для выполнения операций CRUD (Create, Read, Update, Delete) с соответствующими таблицами базы данных. Классы Stock и Comment указываются в качестве типов данных для этих наборов.
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}