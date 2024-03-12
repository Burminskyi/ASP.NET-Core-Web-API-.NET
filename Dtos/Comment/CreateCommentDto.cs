using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Comment
{
    public class CreateCommentDto
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
    }
}