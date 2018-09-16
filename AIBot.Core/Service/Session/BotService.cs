using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AIBot.Core.Domain;
using AIBot.Core.Domain.Master;
using AIBot.Core.Dto;
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

        public async Task<QuestionDto> Read(int userid,int sessionid,int index)
        {
            try
            {
                var questionid = 0;
                Expression<Func<Question, bool>> exp = null;
                if (index <= GlobalConfig.QuestionLandingBoundIndex[1])
                {
                    exp = p => p.Id == index;
                }
                else
                {
                    try
                    {
                        questionid = await GetRandomQuestionId(userid, sessionid);
                        exp = p => p.Id == questionid;
                    }
                    catch (RecordNotFound e)
                    {
                        var sessionId = Guid.NewGuid();
                        await OverSession(sessionid, sessionId);
                        exp = p => p.QuestionType == Enums.QuestionType.Over;
                    }
                }
                var result = Mapper.Map<QuestionDto>(await _uow.QuestionRepository.TableAsNoTracking
                    .Where(exp).FirstAsync());
                if (result.IsNull())
                {
                    throw new RecordNotFound();
                }
                return result;

            }
            catch (Exception e)
            {
                throw;
            }
        }


        async Task OverSession(int sessionid,Guid sessionGuid)
        {
            var result = (await (from sessionAnswer in _uow.UserSessionAnswerRepository.TableAsNoTracking
                    join question in _uow.QuestionRepository.TableAsNoTracking on sessionAnswer.QuestionId equals
                        question.Id
                    where sessionAnswer.UserSessionId == sessionid
                    select new
                    {
                        question.StressType,
                        sessionAnswer.Value
                    }).ToListAsync()).Select(p => new KeyValuePareInfo<Enums.StressType, int>(p.StressType, p.Value))
                .ToList();

                var anxietyValue = Convert.ToDecimal(result.Where(p => p.Key == Enums.StressType.Anxiety).ToList().Sum(p => p.Value)) / 25 * 21;
                var depressionValue = Convert.ToDecimal(result.Where(p => p.Key == Enums.StressType.Depression).ToList().Sum(p => p.Value)) / 25 *
                                      21;
                var stressValue = Convert.ToDecimal(result.Where(p => p.Key == Enums.StressType.Stress).ToList().Sum(p => p.Value)) / 25 * 21;


                var sessionObject = _uow.UserSessionRepository.Get(sessionid);
            var rd = new Random();
            sessionObject.SetResults(rd.Next(10, 50), rd.Next(10, 50), rd.Next(10, 50), sessionGuid);
            await _uow.SaveAsync();
        }

        async Task<int> GetRandomQuestionId(int userid,int sessionid)
        {

            //get all questions
            var allQuestions = await _uow.QuestionRepository.TableAsNoTracking
                .Where(p => p.QuestionType == Enums.QuestionType.Question)
                .Select(p => p.Id).ToListAsync(); 

            var answerdQuestions = await _uow.UserSessionAnswerRepository.TableAsNoTracking.Where(p => p.UserSessionId == sessionid)
                .Select(p => p.QuestionId).ToListAsync();

            allQuestions.RemoveAll(p => answerdQuestions.Contains(p));

            if (allQuestions.IsNull() || allQuestions.Count == 0)
            {
                throw new RecordNotFound("question are over");
            }

            var rd = new Random();
            var randomIndex = rd.Next(0, allQuestions.Count - 1);
            return allQuestions[randomIndex];
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
