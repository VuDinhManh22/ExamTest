namespace BEFinal.Dtos
{
    public class ExamUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Subject { get; set; }
        public string? Level { get; set; }
        public DateTime? ExamDate { get; set; }
    }
}
