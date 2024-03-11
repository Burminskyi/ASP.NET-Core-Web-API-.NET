using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = "";
        public string CompanyName { get; set; } = "";

        //----------------
        // Атрибут [Column] в C# используется для настройки отображения свойств класса в столбцы базы данных при использовании Entity Framework Core или других ORM (Object-Relational Mapping) инструментов. В данном случае, атрибут [Column(TypeName = "decimal(18,2)")] применяется к свойствам Purchase и LastDiv класса Stock.

        // decimal (18,2) указывает на тип данных в базе данных.В контексте базы данных это означает числовой тип данных с фиксированной точностью и масштабом.

        // Числовой тип данных с фиксированной точностью означает, что числа будут иметь фиксированное количество цифр до и после запятой.
        // (18,2) указывает, что всего может быть 18 цифр, из которых 2 будут после запятой.
        // Таким образом, это обеспечивает, что значения свойств Purchase и LastDiv будут храниться в базе данных как числа с двумя цифрами после запятой и общей точностью до 18 цифр.Это обычно используется для хранения денежных значений, чтобы гарантировать точность и избежать ошибок округления при вычислениях.

        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }


        public string Industry { get; set; } = "";
        public long MarketCap { get; set; }

        //----------------
        //Это свойство Comments, которое представляет список комментариев к акции. Каждый элемент списка является экземпляром класса Comment.
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}