using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFinal.Models
{
    public class ExamHistory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ExamId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string FieldChanged { get; set; } = string.Empty;

        [Required]
        public string FromValue { get; set; } = string.Empty;

        [Required]
        public string ToValue { get; set; } = string.Empty;

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }
    }
}
