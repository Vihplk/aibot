using System.Collections.Generic;
using System.Threading.Tasks;
using AIBot.Core.Dto;

namespace AIBot.Core.Service.Interface
{
    public interface IUserRandomQuestionService
    {
        Task<List<UserRandomQuestionDto>> ReadRandomQuestionAnswer();
    }
}
