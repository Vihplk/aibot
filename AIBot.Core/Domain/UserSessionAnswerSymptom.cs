using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.SymbolStore;
using AIBot.Core.Utility;

namespace AIBot.Core.Domain
{
    [Table("UserSessionAnswerSymptom")]
    public class UserSessionAnswerSymptom: Entity
    {
        public int SessionId { get; protected set; }

        public bool Yes { get; protected set; }
        public Enums.SymptomKind SymptomKind { get; protected set; }
        public string Symptoms { get; protected set; }

        public UserSessionAnswerSymptom()
        {
            
        }

        public UserSessionAnswerSymptom(int sessionid,bool yes, Enums.SymptomKind kind,string symptom)
        {
            SessionId = sessionid;
            Yes = yes;
            SymptomKind = kind;
            Symptoms = symptom;
        }
    }
}
