using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;

namespace AIBot.Core.Service.Interface
{
    public interface IQuestionSessionService
    {
        Task<int> CreateSession(int userid);
        Task<List<KeyValuePair<int, DateTime>>> GetAllSession(int userid);
        Task<List<UserSessionAnswerDto>> GetSessionInfo(int sessionid);
        Task<List<AnswerDto>> GetAllPossibleSystemAnswers();
        Task<List<KeyValuePair<decimal, string>>> GetResultGraph(int userid);
        Task<List<decimal>> GetResults(int userid);
    }
}
