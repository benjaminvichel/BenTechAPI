namespace BenTechAPI.Endpoints.UserEnpoint.UserUpdateEndpoint
{
    public class UpdateUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
