using BEFinal;
using BEFinal.Data;
using BEFinal.Dtos;
using BEFinal.Models;
using BEFinal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ITokenService _tokenService;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthController(AppDbContext db, ITokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
            _passwordHasher = new PasswordHasher<User>();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            req.Username = req.Username.Trim().ToLower();

            if (await _db.Users.AnyAsync(u => u.Username == req.Username))
                return BadRequest(new { message = "Tên người dùng đã tồn tại" });

            var user = new User
            {
                Username = req.Username,
                Fullname = req.Fullname
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, req.Password);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var resp = new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Fullname = user.Fullname,
                CreatedAt = user.CreatedAt
            };

            return CreatedAtAction(null, resp);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var username = req.Username.Trim().ToLower();
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) return Unauthorized(new { message = "Tên người dùng không chính xác" });

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, req.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new { message = "Mật khẩu không đúng" });

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }
    }
}
