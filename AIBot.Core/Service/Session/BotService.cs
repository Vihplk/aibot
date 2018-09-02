using System.Linq;
using System.Threading.Tasks;
using AIBot.Core.Domain;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;
using AIBot.Core.Infrastructure;
using AIBot.Core.Service.Interface;
using AIBot.Core.Utility;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AIBot.Core.Service.Session
{
    public class BotService : IBotService
    {
        private readonly IUnitOfWork _uow;
        private UnitOfWork unitOfWork;

        public BotService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<QuestionDto> Read(int request)
        {
            var result = Mapper.Map<QuestionDto>(await _uow.QuestionRepository.TableAsNoTracking
                .Where(p => p.Id == request).FirstAsync());

            if (result.IsNull())
            {
                throw new RecordNotFound();
            }
            return result;
        }
        public async Task GiveAnswer(UserAnswerDto request)
        {
            var @answer = new UserSessionAnswer(request.SessionId,request.QuestionId);
            @answer  = @answer.CreateAnswer(request.AnswerName).SetMatchingAnswer(request.MatchingAnswerId,request.MatchingPercentageSummary, request.Value);
           _uow.UserSessionAnswerRepository.Insert(@answer);
            await _uow.SaveAsync();
        }
    }
}
