using System.ComponentModel.DataAnnotations.Schema;

namespace AIBot.Core.Domain
{
    [Table("UserRandomQuestion")]
    public class UserRandomQuestion:Entity
    {
        public string PossibleQuestion { get; set; }
        public string PossibleAnswer { get; set; }
    }
}
