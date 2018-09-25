using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AIBot.Core.Dto.QuestionAndAnswer.Master;
using AIBot.Model;
using Newtonsoft.Json;
using AIBot.Core;
using AIBot.Core.Utility;

namespace AIBot.Controllers
{
    public partial class ChatBotController
    {
        async Task<MatchAnswerDto> Compare(string compare, List<AnswerDto> comparewith)
        {
            compare = compare.Replace(" ", "+");
            var responses = new List<TwinwordResponse>();
            for (var i = 0; i < comparewith.Count - 1; i++)
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
            if (max < GlobalConfig.DefaultChatTreshold)
            {
                throw new AnswerCannotIdentity();
            }
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

        async Task<string> Compare(string compare, List<string> comparewith)
        {
            compare = compare.Replace(" ", "+");
            comparewith.ForEach(p => p = p.Replace(" ", "+"));
            var responses = new List<TwinwordResponse>();
            foreach (var item in comparewith)
            {
                var url = $@"{GlobalConfig.TwaipApiEndpoint}?text1={compare}&text2={item}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("X-Twaip-Key", GlobalConfig.TwaipKey);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                    var json = await client.GetStringAsync(url);
                    var response = JsonConvert.DeserializeObject<TwinwordResponse>(json);
                    response.question = item;
                    responses.Add(response);
                }
            }
            var max = responses.Max(p => p.similarity);
            if (max < GlobalConfig.DefaultChatTreshold)
            {
                throw new AnswerCannotIdentity();
            }

            return responses.First(p => p.similarity == max).question;
        }

    }
}
