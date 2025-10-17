using System.ComponentModel.DataAnnotations;

namespace BEFinal.Dtos
{
    public class ExamCreateDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Subject { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [RegularExpression("EASY|MEDIUM|HARD", ErrorMessage = "Mức độ được chia ra từ dễ, trung bình, khó")]
        public string Level { get; set; } = "EASY";

        [Required]
        public DateTime ExamDate { get; set; }
    }
}
