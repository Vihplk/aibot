namespace AIBot.Core.Dto.Security
{
    public class LoginRequestDto : BaseDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
