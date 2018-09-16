using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIBot.Core.Domain
{
    [Table("User")]
    public class User: Entity
    {
        [StringLength(20), Column(TypeName = "VARCHAR(20)")]
        public string Name { get; set; }
        [StringLength(20),EmailAddress, Column(TypeName = "VARCHAR(20)")]
        public string Email { get; set; }
        [StringLength(50), Column(TypeName = "VARCHAR(50)")]
        public string Password { get; set; }

        public User Create(string name,string email,string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            return this;
        }
    }
}
