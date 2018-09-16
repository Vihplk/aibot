﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AIBot.Core.Domain;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;
using AIBot.Core.Dto.ViewResult;
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
                        .Where(p => p.UserId == userid && p.IsSessionComplete).Select(p => new {p.Id, p.DateTime}))
                    .OrderByDescending(p => p.Id)
                    .ToListAsync()).Select(p => new KeyValuePair<int, DateTime>(p.Id, p.DateTime))
                .ToList();
        }

        public async Task<List<UserSessionAnswerDto>> GetSessionInfo(int sessionid)
        {
            var questions = await _unitOfWork.QuestionRepository.TableAsNoTracking
                .Where(p=>p.QuestionType == Enums.QuestionType.Question).ToListAsync();

            var answers = await _unitOfWork.UserSessionAnswerRepository.TableAsNoTracking
                .Where(p => p.UserSessionId == sessionid).ToListAsync();

            var result = new List<UserSessionAnswerDto>();
            var index = 1;
            foreach (var item in questions)
            {
                var answeritem = answers.FirstOrDefault(p => p.QuestionId == item.Id);
                var value = -1;
                var matchingPercentageSummery = string.Empty;
                var answer = string.Empty;
                if (!answeritem.IsNull())
                {
                    answer = answeritem.UserAnswer;
                    value = answeritem.Value;
                    matchingPercentageSummery = answeritem.MatchingPercentageSummery;
                }
                result.Add(new UserSessionAnswerDto(index,item.QuestionName, answer, value, matchingPercentageSummery));
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

        public async  Task<List<ChartViewReuslt>> GetResultGraph(int userid)
        {
            try
            {
                var result = await _unitOfWork.UserSessionRepository.TableAsNoTracking
                    .Where(p => p.UserId == userid && p.IsSessionComplete)
                    .Select(p => new { p.AnxietyMarks, p.StressMarks, p.DateTime, p.Id, p.DepressionMarks })
                    .OrderBy(p => p.Id)
                    .ToListAsync();

                var fresult = result.Select(p =>
                        new ChartViewReuslt(p.StressMarks, p.DepressionMarks, p.AnxietyMarks, p.DateTime))
                    .ToList();
                return fresult;
            }
            catch (Exception e)
            {
                throw;
            }
        
        }

        public async Task<List<decimal>> GetResults(int userid, Enums.StressType stessType)
        {
            var result = await _unitOfWork.UserSessionRepository.TableAsNoTracking
                .Where(p => p.UserId == userid && p.IsSessionComplete).Select(p => new
                {
                    p.AnxietyMarks,
                    p.DepressionMarks,
                    p.StressMarks,
                    p.Id
                })
                .OrderBy(p => p.Id)
                .ToListAsync();
            switch (stessType)
            {
                case Enums.StressType.Anxiety:
                    return result.Select(p => p.AnxietyMarks).ToList();
                case Enums.StressType.Stress:
                    return result.Select(p => p.StressMarks).ToList();
                case Enums.StressType.Depression:
                    return result.Select(p => p.DepressionMarks).ToList();
                default:
                    throw new ArgumentException();
            } 
        }

        public Enums.Game GetGame(string token)
        {
            var result = _unitOfWork.UserSessionRepository.TableAsNoTracking
                .FirstOrDefault(p => p.SessionGuid == new Guid(token));

            if (result.IsNull())
            {
                throw new RecordNotFound();
            }

            var marks = new List<decimal>() {result.StressMarks, result.AnxietyMarks, result.DepressionMarks};

            var max = marks.Max();
            var index = marks.IndexOf(max);
            Enums.Game gameState = index == 0 ? Enums.Game.StressOne :
                index == 1 ? Enums.Game.Anx : Enums.Game.Dep;
            ;

            if (gameState==Enums.Game.StressOne)
            {
                gameState = max < 33.3m ? Enums.Game.StressOne :
                    max < 66.7m ? Enums.Game.StressTwo : Enums.Game.StresThree;
            }
            return gameState;
        }
    }
}
