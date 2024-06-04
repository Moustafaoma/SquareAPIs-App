using Square.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Core.DTOs
{
    public class CommentDto
    {
       
        public int UserId { get; set; }

        public int PostId { get; set; }
        
        //[DataType(DataType.DateTime)]
        //public DateTime PostedAt { get; set; } = DateTime.Now;
        [StringLength(1000, ErrorMessage = "The comment cannot exceed 1000 characters.")]
        public string Comment { get; set; }
    }
}
