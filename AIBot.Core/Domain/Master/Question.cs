using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AIBot.Core.Utility;

namespace AIBot.Core.Domain.Master
{
    [Table("Question")]
    public class Question: Entity
    {
        [StringLength(1000), Column(TypeName = "VARCHAR(1000)")]
        public string QuestionName { get; set; }
        public int Order { get; set; } 
        public Enums.StressType StressType { get; set; }
        public Enums.QuestionType QuestionType { get; set; }
    }
}
