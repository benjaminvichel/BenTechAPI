using BenTechAPI.Data;
using FastEndpoints;
using FastEndpoints.AspVersioning;

namespace BenTechAPI.Endpoints.UserEnpoint.UserDeleteEndpoint
{
    public class UserDeleteEndpoint : EndpointWithoutRequest<UserDeleteResponse>
    {
        private readonly ApplicationDBContext _context;

        public UserDeleteEndpoint(ApplicationDBContext context)
        {
            _context = context;
        }

        public override void Configure()
        {

            // Configuração do parâmetro id na URL
            Delete("api/users/delete/{id}");
            Policies("AdminOnly");
            Options(x => x.WithVersionSet(">>User<<")
            .MapToApiVersion(1.0));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<Guid>("id");
            var user = await _context.User.FindAsync(id, ct);
            if (user == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync(ct);

            var response = new UserDeleteResponse
            {
                UserName = user.User_name
            };

            await SendAsync(response);
        }
    }
}