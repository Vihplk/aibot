using AIBot.Core.Domain;
using AIBot.Core.Domain.Master;
using Microsoft.EntityFrameworkCore;

namespace AIBot.Core.Infrastructure
{
    public class AIBotDbContext : Microsoft.EntityFrameworkCore.DbContext, IAIBotDbContext
    {
        private readonly string connectionString;
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserSession> UserSession { get; set; }
        public DbSet<UserSessionAnswer> UserSessionAnswer { get; set; }
        public DbSet<UserSessionGame> UserSessionGame { get; set; }

        public AIBotDbContext()
        {
            connectionString = GlobalConfig.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSessionAnswer>()
                .HasIndex(c => new { c.UserSessionId,c.QuestionId }).IsUnique();
        }
    }
}
