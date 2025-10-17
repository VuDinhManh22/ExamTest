using BEFinal.Models;

namespace BEFinal.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
