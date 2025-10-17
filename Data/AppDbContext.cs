using BEFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace BEFinal.Data
{
    public class AppDbContext : DbContext
    {   
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options) { }

            public DbSet<User> Users { get; set; } = null!;

            public DbSet<Exam> Exams { get; set; }

            public DbSet<ExamHistory> ExamHistories { get; set; }

    }
}
