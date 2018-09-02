using System;
using System.Threading.Tasks;
using AIBot.Core.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AIBot.Controllers
{
    [Route("api")]
    public class UserSessionController: BaseController
    {
        private readonly IQuestionSessionService _sessionService;
        public UserSessionController(IQuestionSessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost,Route("sessions")]
        public async Task<IActionResult> CreateSession()
        {
            try
            {

                return Ok(await _sessionService.CreateSession(UserId));
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }
        [HttpGet, Route("sessions")]
        public async Task<IActionResult> GetAllSession()
        {
            try
            {
                return Ok(await _sessionService.GetAllSession(UserId));
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }
        [HttpGet, Route("sessions/{id:int}")]
        public async Task<IActionResult> GetSessionInfo(int id)
        {
            try
            {
                return Ok(await _sessionService.GetSessionInfo(id));
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }

        [HttpGet, Route("sessions/graph")]
        public async Task<IActionResult> GetResultGraph()
        {
            try
            {
                return Ok(await _sessionService.GetResultGraph(UserId));
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }
    }
}
