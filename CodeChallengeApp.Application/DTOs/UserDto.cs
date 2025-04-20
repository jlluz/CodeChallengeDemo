namespace CodeChallengeApp.Application.DTOs
{
    public class UserDto
    {
        public required string UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
