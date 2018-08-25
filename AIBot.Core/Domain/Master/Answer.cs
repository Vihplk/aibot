using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIBot.Core.Domain.Master
{
    public class Answer : Entity
    {
        [StringLength(200), Column(TypeName = "VARCHAR(200)")]
        public string AnswerName { get; set; }
        public int Value { get; set; } = 0;
    }
}
