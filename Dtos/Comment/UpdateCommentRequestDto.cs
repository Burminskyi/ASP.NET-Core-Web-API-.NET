using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters at least")]
        [MaxLength(280, ErrorMessage = "Title can't be over 280 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content must be 5 characters at least")]
        [MaxLength(280, ErrorMessage = "Content can't be over 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}