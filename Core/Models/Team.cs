using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
   public class Team
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="Uzunluq 50den cox ola bilmez!")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Uzunluq 100den cox ola bilmez!")]
        public string Description { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Uzunluq 50den cox ola bilmez!")]
        public string Position { get; set; }
        public string ? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ? PhotoFile { get; set; }
    }
}
