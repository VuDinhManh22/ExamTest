using System.ComponentModel.DataAnnotations;

namespace BEFinal.Dtos
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string Fullname { get; set; } = null!;
    }
}
