namespace AIBot.Core.Dto.Security
{
    public class LoginResponseDto:BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public LoginResponseDto(string email,string name,int id)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
