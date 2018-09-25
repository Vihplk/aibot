using System.Threading.Tasks;
using AIBot.Core.Domain;
using AIBot.Core.Domain.Master;

namespace AIBot.Core.Infrastructure
{
    public interface IUnitOfWork
    {
        Repository<User> UserRepository { get; }
        Repository<Question> QuestionRepository { get; }
        Repository<Answer> AnswerRepository { get; }
        Repository<UserSession> UserSessionRepository { get; }
        Repository<UserSessionAnswer> UserSessionAnswerRepository { get; }
        Repository<UserSessionGame> UserSessionGameRepository { get; }
        Repository<UserSessionAnswerSymptom> UserSessionAnswerSymptomRepository { get; }
        Repository<UserRandomQuestion> UserRandomQuestionRepository { get; }
        Task<int> SaveAsync();
    }
}
