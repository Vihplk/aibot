using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;
using AIBot.Core.Service.Interface;
using AIBot.Core.Utility;
using AIBot.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AIBot.Controllers
{
    [Route("api/chat")]
    public partial class ChatBotController : BaseController
    {
        private readonly IBotService _botService;
        private readonly IQuestionSessionService _questionSession;
        public ChatBotController(IBotService botService, IQuestionSessionService questionSession)
        {
            _botService = botService;
            _questionSession = questionSession;
        }
        [HttpGet,Route("questions/{sessionid:int}/{index:int}")]
        public async Task<IActionResult> ReadQuestion(int sessionid,int index)
        {
            try
            {
                var question = (await _botService.Read(UserId, sessionid, index));
                question.QuestionName = question.QuestionName.ApplyRegx(DisplayName);
                return Ok(question);
            }
            catch(OverExamException e)
            {
                return Ok(new QuestionDto
                {
                    IsQuestion = false,
                    QuestionName = e.Message
                });
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
          
        }
        [HttpPost("answer")]
        public async Task<IActionResult> GiveAnswer([FromBody]UserAnswerDto request)
        {
            try
            {
                if (request.IsQuestionOver())
                {
                    return Ok(new QuestionDto
                    {
                        Id = 32,
                        Order = 0,
                        QuestionName = "Question Are Over"
                    });
                }
                if (request.IsQuestion())
                {
                    var possibleSysAnswers = await _questionSession.GetAllPossibleSystemAnswers();
                    var mostSutable = await Compare(request.AnswerName, possibleSysAnswers);
                    request.Value = mostSutable.MatchingAnswerValue;
                    request.MatchingAnswerId = mostSutable.MatchingAnswerId;
                    request.MatchingPercentageSummary = mostSutable.Summary;
                    await _botService.GiveAnswer(request);
                }

                return await ReadQuestion(request.SessionId, request.Index);
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }

   
        [HttpGet("compare")]
        public async Task<IActionResult> Compare(string compare, string comparewith)
        {
            return Ok(Compare(compare, new List<string>() {comparewith}));
        }

    }
}
