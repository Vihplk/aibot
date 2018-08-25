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
using Microsoft.EntityFrameworkCore;

namespace AIBot.Core.Service.Session
{
    public class QuestionSessionService : IQuestionSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionSessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateSession(int userid)
        {
            var @userSession = new UserSession();
            var session = @userSession.CreateSession(userid);
            _unitOfWork.UserSessionRepository.Insert(session);
            await _unitOfWork.SaveAsync();
            return session.Id;
        }

        public async Task<List<KeyValuePair<int, DateTime>>> GetAllSession(int userid)
        {
            return (await (_unitOfWork.UserSessionRepository.TableAsNoTracking
                        .Where(p => p.UserId == userid).Select(p => new {p.Id, p.DateTime}))
                    .ToListAsync()).Select(p => new KeyValuePair<int, DateTime>(p.Id, p.DateTime))
                .ToList();
        }

        public async Task<List<UserSessionAnswerDto>> GetSessionInfo(int sessionid)
        {
            var questions = await _unitOfWork.QuestionRepository.TableAsNoTracking
                .Where(p=>p.IsQuestion).ToListAsync();

            var answers = await _unitOfWork.UserSessionAnswerRepository.TableAsNoTracking
                .Where(p => p.UserSessionId == sessionid).ToListAsync();

            var result = new List<UserSessionAnswerDto>();
            var index = 1;
            foreach (var item in questions)
            {
                var answeritem = answers.FirstOrDefault(p => p.QuestionId == item.Id);
                var ans = answeritem.IsNull() ? "" : answeritem.UserAnswer;
                result.Add(new UserSessionAnswerDto(index,item.QuestionName,ans,answeritem.Value,answeritem.MatchingPercentageSummery));
                index++;
            }
            return result;
        }

        public async Task<List<AnswerDto>> GetAllPossibleSystemAnswers()
        {
            return (await _unitOfWork.AnswerRepository.TableAsNoTracking
                    .ToListAsync()).Select(AutoMapper.Mapper.Map<AnswerDto>)
                .ToList();
        }
    }
}
