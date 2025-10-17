using AutoMapper;
using BEFinal.Data;
using BEFinal.Dtos;
using BEFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BEFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ExamsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] ExamCreateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
               return Unauthorized();
            }

            var exam = _mapper.Map<Exam>(dto);
            exam.CreatorId = Guid.Parse(userId);

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ExamResponseDto>(exam);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetExams([FromQuery] string? subject, [FromQuery] string? level)
        {
            var query = _context.Exams.AsQueryable();

            if (!string.IsNullOrEmpty(subject))
                query = query.Where(e => e.Subject == subject);
            if (!string.IsNullOrEmpty(level))
                query = query.Where(e => e.Level == level);

            var exams = await query.ToListAsync();
            var result = _mapper.Map<List<ExamResponseDto>>(exams);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(Guid id, [FromBody] ExamUpdateDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            var isOwner = exam.CreatorId == Guid.Parse(userId);
            var isAdmin = User.IsInRole("Admin");

            if (!isOwner && !isAdmin) return Forbid();
            var histories = new List<ExamHistory>();

            if (!string.IsNullOrEmpty(dto.Level) && dto.Level != exam.Level)
            {
                histories.Add(new ExamHistory
                {
                    ExamId = exam.Id,
                    UserId = Guid.Parse(userId),
                    FieldChanged = "level",
                    FromValue = exam.Level,
                    ToValue = dto.Level,
                    ChangedAt = DateTime.UtcNow
                });

                exam.Level = dto.Level;
            }

            if (dto.ExamDate.HasValue && dto.ExamDate.Value != exam.ExamDate)
            {
                histories.Add(new ExamHistory
                {
                    ExamId = exam.Id,
                    UserId = Guid.Parse(userId),
                    FieldChanged = "examDate",
                    FromValue = exam.ExamDate.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    ToValue = dto.ExamDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    ChangedAt = DateTime.UtcNow
                });

                exam.ExamDate = dto.ExamDate.Value;
            }

            if (!string.IsNullOrEmpty(dto.Title)) exam.Title = dto.Title;
            if (!string.IsNullOrEmpty(dto.Subject)) exam.Subject = dto.Subject;
            if (!string.IsNullOrEmpty(dto.Description)) exam.Description = dto.Description;

            if (histories.Any())
                _context.ExamHistories.AddRange(histories);

            await _context.SaveChangesAsync();

            var result = _mapper.Map<ExamResponseDto>(exam);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetExamHistory(Guid id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) return NotFound();

            var histories = await _context.ExamHistories
                .Where(h => h.ExamId == id)
                .OrderByDescending(h => h.ChangedAt)
                .ToListAsync();

            return Ok(histories);
        }

        [Authorize]
        [HttpGet("statistics")]
        public async Task<IActionResult> GetExamStatistics()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var guidUserId = Guid.Parse(userId);

            var exams = await _context.Exams
                .Where(e => e.CreatorId == guidUserId)
                .ToListAsync();

            var dto = new ExamStatisticsDto();

            if (exams.Count == 0)
                return Ok(dto); 

            dto.Total = exams.Count;
            dto.Easy = exams.Count(e => e.Level == "EASY");
            dto.Medium = exams.Count(e => e.Level == "MEDIUM");
            dto.Hard = exams.Count(e => e.Level == "HARD");
            dto.HardRate = Math.Round((double)dto.Hard / dto.Total * 100, 2);
            dto.Subjects = exams
                .GroupBy(e => e.Subject)
                .ToDictionary(g => g.Key, g => g.Count());

            return Ok(dto);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) return NotFound();

            var isOwner = exam.CreatorId == Guid.Parse(userId);
            var isAdmin = User.IsInRole("Admin");

            if (!isOwner && !isAdmin) return Forbid();

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
