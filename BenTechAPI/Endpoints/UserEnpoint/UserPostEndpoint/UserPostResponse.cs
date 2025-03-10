namespace BenTechAPI.Endpoints.UserEnpoint.UserPostEndpoint
{
    public class UserPostResponse
    {
        public string User_name { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
