namespace BenTechAPI.Endpoints.UserEnpoint.UserUpdateEndpoint
{
    public class UpdateUser
    {
        public Guid Id { get; set; }
        public string User_name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
