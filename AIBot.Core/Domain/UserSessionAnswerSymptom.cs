using System.ComponentModel.DataAnnotations.Schema;
using AIBot.Core.Utility;

namespace AIBot.Core.Domain
{
    [Table("UserSessionAnswerSymptom")]
    public class UserSessionAnswerSymptom: Entity
    {
        public int SessionId { get; set; }

        public bool Yes { get; set; }
        public Enums.SymptomKind SymptomKind { get; set; }
        public string Symptoms { get; set; }
    }
}
