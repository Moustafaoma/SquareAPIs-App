using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Core.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Users? User { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Posts? Post { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PostedAt { get; set; }= DateTime.Now;
        [StringLength(1000, ErrorMessage = "The comment cannot exceed 1000 characters.")]
        public string Comment { get; set; }

    }
}
