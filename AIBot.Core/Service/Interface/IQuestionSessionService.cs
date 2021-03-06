﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AIBot.Core.Domain;
using AIBot.Core.Dto.QuestionAndAnswer;
using AIBot.Core.Dto.QuestionAndAnswer.Master;
using AIBot.Core.Dto.ViewResult;
using AIBot.Core.Utility;
using static AIBot.Core.Utility.Enums;

namespace AIBot.Core.Service.Interface
{
    public interface IQuestionSessionService
    {
        Task<int> CreateSession(int userid);
        Task<List<KeyValuePair<int, string>>> GetAllSession(int userid);
        Task<List<UserSessionAnswerDto>> GetSessionInfo(int sessionid);
        Task<List<AnswerDto>> GetAllPossibleSystemAnswers();
        Task<List<ChartViewReuslt>> GetResultGraph(int userid);
        Task<List<decimal>> GetResults(int userid, Enums.StressType stessType);
        Enums.Game GetGame(string token);
        //game
        void SaveGameScore(Guid sessionid,int gameid,int success,int failed);
        Task<List<GameViewResult>> GetGameResult(int sessionid);

        //symptoms

        void SaveSessionSymptomes(int sessionid, Dictionary<Enums.SymptomKind, List<string>> info);

        Task<List<KeyValuePair<string, int>>> SessionSymptomes(int sessionid);
    }
}
