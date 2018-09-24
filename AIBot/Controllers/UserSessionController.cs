using System;
using System.Linq;
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
                var resule = await _sessionService.GetResultGraph(UserId);
                return Ok(new
                {
                    yaxe = resule.Select(p=>p.Date).ToList(),
                    stress = resule.Select(p=>p.Stress).ToList(),
                    anix = resule.Select(p => p.Anxiety).ToList(),
                    depression = resule.Select(p => p.Depression).ToList(),
                });
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }
        [HttpGet, Route("sessions/game/{token}")]
        public int GameAccess(string token)
        {
            return (int) _sessionService.GetGame(token);
        }

        [HttpGet, Route("sessions/game/{session}/{type}/{success}/{failed}")]
        public void SaveGameScore(string session,int type,int success,int failed)
        {
            _sessionService.SaveGameScore(new Guid(session), type, success, failed);
        }

        [HttpGet, Route("sessions/game/score/{session}")]
        public async Task<IActionResult> GetGameScore(int session)
        {
           return Ok(await _sessionService.GetGameResult(session));
        }
    }
}
