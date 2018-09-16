using System;
using System.Threading.Tasks;
using AIBot.Core.Dto.Security;
using AIBot.Core.Infrastructure;
using AIBot.Core.Service.Interface;
using AIBot.Core.Utility;
using Microsoft.EntityFrameworkCore;

namespace AIBot.Core.Service.User
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {
            try
            { 
                var result = await _unitOfWork.UserRepository.TableAsNoTracking
                    .FirstOrDefaultAsync(p =>
                        p.Email == request.Email && p.Password == request.Password);
                if (result.IsNull())
                {
                    throw new RecordNotFound("invalied username or password");
                }
                return new LoginResponseDto(result.Email, result.Name, result.Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<LoginResponseDto> Register(RegisterDto request)
        {
            try
            {
                var @user = new Domain.User().Create(request.Name, request.Email,
                    request.Password);
                _unitOfWork.UserRepository.Insert(@user);
                await _unitOfWork.SaveAsync();
                return new LoginResponseDto(request.Email, request.Name, @user.Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
