using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Square.Core.Models
{
    public class Posts
    {
        public int Id { get; set; }  // Primary key, no validation needed

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title must not exceed 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "URL is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string URL { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;
        public int UsersId {get; set; }
        public virtual Users? Users { get; set; }
    }
}
