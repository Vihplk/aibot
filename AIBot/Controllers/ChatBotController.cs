using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;
using AIBot.Core.Service.Interface;
using AIBot.Core.Utility;
using AIBot.Model;
using Microsoft.AspNetCore.Mvc;

namespace AIBot.Controllers
{
    [Route("api/chat")]
    public partial class ChatBotController : BaseController
    {
        private readonly IBotService _botService;
        private readonly IQuestionSessionService _questionSession;
        private readonly IUserRandomQuestionService _userRandomQuestionService;
        public ChatBotController(IBotService botService, IQuestionSessionService questionSession,
            IUserRandomQuestionService userRandomQuestionService)
        {
            _botService = botService;
            _questionSession = questionSession;
            _userRandomQuestionService = userRandomQuestionService;
        }
        [HttpGet,Route("questions/{sessionid:int}/{index:int}")]
        public async Task<IActionResult> ReadQuestion(int sessionid,int index,bool isRepeat=false,string answertoUserRandomeQuestion = "")
        {
            try
            {
                if (isRepeat)
                {
                    return BadRequest("cannot identify the answer");
                }
                var question = (await _botService.Read(UserId, sessionid, index));
                question.QuestionName = $"{answertoUserRandomeQuestion}{question.QuestionName.ApplyRegx(DisplayName)}";
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
                var answer = string.Empty;
                var question = string.Empty;
                var extra = string.Empty;
                var systemAnswer = string.Empty;
                try
                {
                    answer = request.AnswerName.Split('.')[0];
                }
                catch (Exception e)
                {
                    answer = request.AnswerName;
                }

                try
                {
                    var x = request.AnswerName.Split('.')[1];
                    if (x.EndsWith('?'))
                    {
                        question = x;
                    }
                    else
                    {
                        extra = x;
                    }
                }
                catch (Exception e)
                {
                    //eat
                }

                #region handle user random question

                if (!String.IsNullOrEmpty(question))
                {
                    var questions = await _userRandomQuestionService.ReadRandomQuestionAnswer();
                    var result = await Compare(question, questions.Select(p => p.PossibleQuestion).ToList());
                    systemAnswer = questions.First(p => p.PossibleQuestion == result).PossibleAnswer + ".";
                }

                #endregion

                if (request.IsQuestion())
                {
                    var possibleSysAnswers = await _questionSession.GetAllPossibleSystemAnswers();
                    MatchAnswerDto mostSutable;
                    try
                    {
                        mostSutable = await Compare(answer, possibleSysAnswers);
                    }
                    catch (Exception e)
                    {
                        return await ReadQuestion(request.SessionId, request.Index, true, systemAnswer);
                    }

                    request.Value = mostSutable.MatchingAnswerValue;
                    request.MatchingAnswerId = mostSutable.MatchingAnswerId;
                    request.MatchingPercentageSummary = mostSutable.Summary;
                    await _botService.GiveAnswer(request);
                }

                return await ReadQuestion(request.SessionId, request.Index, answertoUserRandomeQuestion: systemAnswer);
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
