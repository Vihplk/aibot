using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AIBot.Core.Domain.Master;

namespace AIBot.Core.Domain
{
    [Table("UserSessionAnswer")]
    public class UserSessionAnswer : Entity
    {
        public int UserSessionId { get; protected set; }
        public int QuestionId { get; protected set; }
        public int MatchingAnswerId { get; protected set; }
        public int Value { get; set; }
        [StringLength(500), Column(TypeName = "VARCHAR(500)")]
        public string UserAnswer { get; protected set; }
        [StringLength(1000), Column(TypeName = "VARCHAR(1000)")]
        public string MatchingPercentageSummery { get; protected set; }



        #region relations

        [ForeignKey("UserSessionId")] public UserSession UserSession { get; set; }
        [ForeignKey("QuestionId")] public Question Question { get; set; }
        [ForeignKey("MatchingAnswerId")] public Answer Answer { get; set; }

        #endregion

        public UserSessionAnswer(int sessionid,int questionid)
        {
            UserSessionId = sessionid;
            QuestionId = questionid;
        }
        public UserSessionAnswer CreateAnswer(string useranswer)
        {   
            UserAnswer = useranswer;
            return this;
        }

        public UserSessionAnswer SetMatchingAnswer(int matchingAnswerid,string matchingPresantageSummary,int value)
        {
            MatchingAnswerId = matchingAnswerid;
            MatchingPercentageSummery  = matchingPresantageSummary;
            Value = value;
            return this;
        }

        public UserSessionAnswer()
        {
            
        }
    }
}
