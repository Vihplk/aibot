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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using unirest_net.http;

namespace AIBot.Controllers
{
    [Route("api/chat")]
    public class ChatBotController : BaseController
    {
        private readonly IBotService _botService;
        private readonly IQuestionSessionService _questionSession;
        public ChatBotController(IBotService botService, IQuestionSessionService questionSession)
        {
            _botService = botService;
            _questionSession = questionSession;
        }
        [HttpGet,Route("questions/{id:int}")]
        public async Task<IActionResult> ReadQuestion(int id)
        {
            try
            {
                var question = (await _botService.Read(id));
                question.QuestionName = question.QuestionName.ApplyRegx(DisplayName);
                return Ok(question);
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
                return await ReadQuestion(++request.QuestionId);
            }
            catch (Exception e)
            {
                return await HandleException(e);
            }
        }

        async Task<MatchAnswerDto> Compare(string compare, List<AnswerDto> comparewith)
        {
            compare = compare.Replace(" ", "+"); 
            var responses = new List<TwinwordResponse>();
            for (var i = 0; i < comparewith.Count-1; i++)
            {
                var item = comparewith[i];
                var url = $@"{GlobalConfig.TwaipApiEndpoint}?text1={compare}&text2={item.AnswerName}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("X-Twaip-Key", GlobalConfig.TwaipKey);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                    var json = await client.GetStringAsync(url);
                    var response = JsonConvert.DeserializeObject<TwinwordResponse>(json);
                    response.answerid = item.Id;
                    responses.Add(response);
                }
            }
            var max = responses.Max(p => p.similarity);
            var matchinganswer = responses.First(p => p.similarity == max);
            return new MatchAnswerDto
            {
                MatchingAnswerId = matchinganswer.answerid,
                MatchingAnswerValue = comparewith.First(p => p.Id == matchinganswer.answerid).Value,
                Summary = JsonConvert.SerializeObject(responses.Select(p => new
                {
                    answer = p.answerid,
                    similarity = p.similarity
                }))
            };
        }

        async Task Compare(string compare,List<string> comparewith)
        {
            compare = compare.Replace(" ", "+");
            comparewith.ForEach(p => p = p.Replace(" ", "+"));
            foreach (var item in comparewith)
            {
                var url = $@"{GlobalConfig.TwaipApiEndpoint}?text1={compare}&text2={item}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("X-Twaip-Key", GlobalConfig.TwaipKey);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                    var json = await client.GetStringAsync(url);
                    var response = JsonConvert.DeserializeObject<TwinwordResponse>(json);
                }
            }
        }

        [HttpGet("compare")]
        public async Task<IActionResult> Compare(string compare, string comparewith)
        {
            return Ok(Compare(compare, new List<string>() {comparewith}));
        }

    }
}
