using FastEndpoints;

namespace BenTechAPI.Endpoints.UserEnpoint.UserGetByIdEndpoint
{
    public class UserGetIdRequest
    {
        [QueryParam, BindFrom("id")]
        public Guid Id { get; set; }
    }
}
