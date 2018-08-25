using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIBot.Core.Domain.Master
{
    [Table("Question")]
    public class Question: Entity
    {
        [StringLength(1000), Column(TypeName = "VARCHAR(1000)")]
        public string QuestionName { get; set; }
        public int Order { get; set; }
        public bool IsQuestion { get; set; }
    }
}
