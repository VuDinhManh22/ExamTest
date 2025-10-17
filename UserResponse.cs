namespace BEFinal
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
