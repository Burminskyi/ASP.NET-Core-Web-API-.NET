using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        //-----------------
        //это свойство StockId, которое представляет идентификатор акции, к которой относится комментарий. Здесь используется тип int?, что означает, что это может быть nullable тип данных (то есть может быть null).
        public int? StockId { get; set; }

        //-----------------
        //это свойство Stock, которое представляет собой связь с объектом Stock, к которому относится комментарий. Здесь используется тип Stock?, что означает, что это может быть nullable тип данных (то есть может быть null).
        public Stock? Stock { get; set; }
    }
}