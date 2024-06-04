using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Core.DTOs
{
    public class PostDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title must not exceed 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "URL is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string URL { get; set; }

        ////[Required]
        ////public DateTime PostedAt { get; set; }=DateTime.Now;
        public int UsersId { get; set; }
    }
}
