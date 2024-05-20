using System.ComponentModel.DataAnnotations;

namespace Lumia.DTO
{
    public class LoginDto
    {
        [Required]
        public string UserNameOrEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool  IsRemember {  get; set; }
    }
}
