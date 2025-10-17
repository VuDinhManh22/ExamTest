using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFinal.Models
{
    public class Exam
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Subject { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty; 
        
        [Required] 
        public string Level { get; set; } = "EASY"; // EASY, MEDIUM, HARD

        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        // Kết nối với cổng user
        [ForeignKey(nameof(CreatorId))]
        public User? Creator { get; set; }
    }
}
