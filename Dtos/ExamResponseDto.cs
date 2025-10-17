namespace BEFinal.Dtos
{
    public class ExamResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Level { get; set; } = string.Empty;
        public DateTime ExamDate { get; set; }
        public Guid CreatorId { get; set; }
    }
}
