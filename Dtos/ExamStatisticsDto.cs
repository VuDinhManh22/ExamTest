namespace BEFinal.Dtos
{
    public class ExamStatisticsDto
    {
        public int Total { get; set; }
        public int Easy { get; set; }
        public int Medium { get; set; }
        public int Hard { get; set; }
        public double HardRate { get; set; }
        public Dictionary<string, int> Subjects { get; set; } = new();
    }
}
