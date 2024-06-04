using Square.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Core.DTOs
{
    public class LikeDto
    {
        public int UserId { get; set; }
        //public virtual Users? User { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
    }
}
