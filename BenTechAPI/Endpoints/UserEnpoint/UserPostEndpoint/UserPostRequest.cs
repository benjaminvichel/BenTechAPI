namespace BenTechAPI.Endpoints.UserEnpoint.UserPostEndpoint
{
    public class UserPostRequest
    {
        public Guid UserId { get; set; }
        public string User_name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
