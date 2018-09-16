using System.Threading.Tasks;
using AIBot.Core.Domain;
using AIBot.Core.Domain.Master;

namespace AIBot.Core.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        public AIBotDbContext Context { get; }

        private Repository<User> userRepository;
        private Repository<Question> questionRepository;
        private Repository<Answer> answerRepository;
        private Repository<UserSession> userSessionRepository;
        private Repository<UserSessionAnswer> userSessionAnswerRepository;
        private Repository<UserSessionGame> userSessionGameRepository;
        public UnitOfWork(IAIBotDbContext dbcontext)
        {
            Context = (AIBotDbContext)dbcontext;
        }

        public Repository<User> UserRepository =>
            userRepository ?? (userRepository = new Repository<User>(Context));

        public Repository<Question> QuestionRepository =>
            questionRepository ?? (questionRepository = new Repository<Question>(Context));

        public Repository<Answer> AnswerRepository =>
            answerRepository ?? (answerRepository = new Repository<Answer>(Context));

        public Repository<UserSession> UserSessionRepository =>
            userSessionRepository ?? (userSessionRepository = new Repository<UserSession>(Context));

        public Repository<UserSessionAnswer> UserSessionAnswerRepository =>
            userSessionAnswerRepository ?? (userSessionAnswerRepository = new Repository<UserSessionAnswer>(Context));

        public Repository<UserSessionGame> UserSessionGameRepository =>
            userSessionGameRepository ?? (userSessionGameRepository = new Repository<UserSessionGame>(Context));

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
