using System;
using System.Threading.Tasks;
using AIBot.Core.Dto.Security;
using AIBot.Core.Service.Interface;
using AIBot.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AIBot.Controllers
{
    [Route("api/security")]
    public class SecurityController : BaseController
    {
        private readonly ISecurityService _securityService;
        private readonly Token _tokenGenarator;
        public SecurityController(ISecurityService securityService, IConfiguration config)
        {
            _securityService = securityService;
            _tokenGenarator = new Token(config);
        }

        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto request)
        {
            try
            {
                var response = await _securityService.Login(request);
                return Ok(_tokenGenarator.JwtTokenBuilder(response));
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }

        [HttpPost, Route("registar"), AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterDto request)
        {
            try
            {
                var response = await _securityService.Register(request);
                return Ok(_tokenGenarator.JwtTokenBuilder(response));
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }
    }
}
