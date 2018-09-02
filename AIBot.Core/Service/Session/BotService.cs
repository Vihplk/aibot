using System;
using System.Collections.Generic;
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
        private const int from = 8;
        private const int to = 29;
        public BotService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<QuestionDto> Read(int request,int userid)
        {
           
            if (request>=@from && request <= to)
            {
                request = await GetRandomQuestionId(userid);
            }

            var result = Mapper.Map<QuestionDto>(await _uow.QuestionRepository.TableAsNoTracking
                .Where(p => p.Id == request).FirstAsync());
            if (result.IsNull())
            {
                throw new RecordNotFound();
            }
            return result;
        }

        async Task<int> GetRandomQuestionId(int userid)
        {
            //get current session
            var currentSession = _uow.UserSessionRepository.TableAsNoTracking.Where(p => p.UserId == userid).Max(p => p.Id);

            var answerdQuestions = await _uow.UserSessionAnswerRepository.TableAsNoTracking.Where(p => p.UserSessionId == currentSession)
                .Select(p => p.QuestionId).ToListAsync();

            var notAnswerdQuestion = new List<int>();
            for (var i = from; i <= to; i++)
            {
                if (!answerdQuestions.Contains(i))
                {
                    notAnswerdQuestion.Add(i);
                }
            }
            var rd = new Random();
            var randomIndex = rd.Next(0, notAnswerdQuestion.Count - 1);
            return notAnswerdQuestion[randomIndex];
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
