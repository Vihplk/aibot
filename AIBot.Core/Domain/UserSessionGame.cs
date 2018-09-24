using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIBot.Core.Domain
{
    [Table("UserSessionGame")]
    public class UserSessionGame : Entity
    {
        public Guid SessionId { get; protected set; }
        public int GameId { get; protected set; }
        public int Success { get; protected set; }
        public int Failed { get; protected set; }

        public UserSessionGame(Guid sessionId,int gameId,int success,int failed)
        {
            SessionId = sessionId;
            GameId = gameId;
            Success = success;
            Failed = failed;
        }

        public UserSessionGame()
        {
            
        }
    }
}
