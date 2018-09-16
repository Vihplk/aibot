using System.Threading.Tasks;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;

namespace AIBot.Core.Service.Interface
{
    public interface IBotService
    {
        Task<QuestionDto> Read(int userid, int sessionid, int index);
        Task GiveAnswer(UserAnswerDto request);
    }
}
