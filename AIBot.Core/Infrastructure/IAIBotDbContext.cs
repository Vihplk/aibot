using AIBot.Core.Domain;
using AIBot.Core.Domain.Master;
using Microsoft.EntityFrameworkCore;

namespace AIBot.Core.Infrastructure
{
    public interface IAIBotDbContext
    {
        DbSet<Answer> Answer { get; set; }
        DbSet<Question> Question { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserSession> UserSession { get; set; }
        DbSet<UserSessionAnswer> UserSessionAnswer { get; set; }
        DbSet<UserSessionGame> UserSessionGame { get; set; }
        DbSet<UserSessionAnswerSymptom> UserSessionAnswerSymptom { get; set; }
        DbSet<UserRandomQuestion> UserRandomQuestion { get; set; }
    }
}
