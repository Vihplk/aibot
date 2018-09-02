using System.Threading.Tasks;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;

namespace AIBot.Core.Service.Interface
{
    public interface IBotService
    {
        Task<QuestionDto> Read(int request, int userid);
        Task GiveAnswer(UserAnswerDto request);
    }
}
