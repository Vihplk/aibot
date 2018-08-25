using System.Threading.Tasks;
using AIBot.Core.Dto.Security;

namespace AIBot.Core.Service.Interface
{
    public interface ISecurityService
    {
        Task<LoginResponseDto> Login(LoginRequestDto request);
    }
}
